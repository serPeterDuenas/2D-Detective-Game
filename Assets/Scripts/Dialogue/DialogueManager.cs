using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;


// TODO: Expand this so more characters and their color text is accounted for
// otherwise, this all works


public class DialogueManager : MonoBehaviour
{
    // var for the load_globals.ink JSON
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]
    [SerializeField] private float textSpeed = 0.04f;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject continueText;
    [SerializeField] private GameObject choiceBoxes;
    [SerializeField] private GameObject speakerPanel;

    [Header("Choices UI")]
    // array of gameobjects to store the buttons on the Canvas
    [SerializeField] private GameObject[] choicesSelections;
    private TextMeshProUGUI[] choicesText;

    [Header("Dialogue Audio")]
    [SerializeField] private DialogueAudioSO defaultAudioInfo;
    [SerializeField] private DialogueAudioSO[] audioInfos;
    private DialogueAudioSO currentAudioInfo;
    private Dictionary<string, DialogueAudioSO> audioInfoDictionary;

    private Story currentStory;
    private DialogueVariables dialogueVariables;
    private Coroutine currentCoroutine;
    private bool canContinueNextLine = false;

    public static DialogueManager instance { get; private set; }
    public bool dialogueIsPlaying { get; private set; }
    public bool endOfDialogue { get;  set; }

    private Interactive interacitve;

    private const string SPEAKER_TAG = "speaker";
    private const string TEXTCOLOR_TAG = "text_color";
    private const string ACTION_TAG = "action";
    private const string AUDIO_TAG = "audio";
    //private const string SPEAKERCOLOR_TAG = "speaker_color";


    private void Awake()
    {
       
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        dialogueVariables = new DialogueVariables(loadGlobalsJSON);

        currentAudioInfo = defaultAudioInfo;
    }


   
    void Start()
    {
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        
        // the amount of texts determined by how many buttons there are
        choicesText = new TextMeshProUGUI[choicesSelections.Length];

        int i = 0;
        foreach (GameObject choice in choicesSelections)
        {
            // text on Canvas filled out by the corresponding button text
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }

        InitializeAudioinfoDictionary();
    }


    private void Update()
    {
        
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }


        // listen for if player pressed "interact" to continue with dialogue
        if (canContinueNextLine
            && currentStory.currentChoices.Count == 0
            && InputManager.instance.GetSubmitPressed())
        {
            ContinueDialogue();
        }

    }



    private void InitializeAudioinfoDictionary()
    {
        audioInfoDictionary = new Dictionary<string, DialogueAudioSO>();
        audioInfoDictionary.Add(defaultAudioInfo.id, defaultAudioInfo);
        foreach(DialogueAudioSO audioInfo in audioInfos)
        {
            audioInfoDictionary.Add(audioInfo.id, audioInfo);
        }

    }


    private void SetCurrentAudioInfo(string id)
    {
        DialogueAudioSO audioInfo = null;
        audioInfoDictionary.TryGetValue(id, out audioInfo);

        if (audioInfo != null)
        {
            this.currentAudioInfo = audioInfo;
        }
        else
        {
            Debug.LogWarning("failed to find info for id: " + id);
        }
    }

    // Begins dialogue, taking in a JSON TextAsset to create a new Story
    public void EnterDialogueMode(TextAsset inkJSON, Interactive _interactive)
    {
        interacitve = _interactive;
        // creates an instance of Story using TextAsset argument
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        endOfDialogue = false;
        dialogueBox.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        
        //print("entering dialogue");

        ContinueDialogue();
    }



    private void ContinueDialogue()
    {
        // If there are any lines in the Story to be played, set the text to the current line
        if (currentStory.canContinue)
        {
            // set text for current dialogue lines
            //textContainer.color = Color.red;
            if(currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            string nextLine = currentStory.Continue();
            // handle tags, specifically to get text color depending on speaker
            HandleTags(currentStory.currentTags);
            currentCoroutine = StartCoroutine(DisplayLine(nextLine));

            // diplay choices if there are any
            DisplayChoices();

    
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }


    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;
        HideChoices();

        canContinueNextLine = false;
       
        //dialogueText.text = line;
        //dialogueText.maxVisibleCharacters = 0;

        foreach(char letter in line.ToCharArray())
        {
            if(InputManager.instance.GetSubmitPressed()) 
            {
                dialogueText.maxVisibleCharacters = line.Length;
                break;
            }
            PlayDialogueSound(dialogueText.maxVisibleCharacters);
            dialogueText.maxVisibleCharacters++;  
           
            yield return new WaitForSeconds(textSpeed);
        }

        canContinueNextLine = true;
        continueText.SetActive(true);
        choiceBoxes.SetActive(true);
    }

    private void PlayDialogueSound(int currentDisplayedCharCount)
    {
        AudioClip soundCLip = RandomizeClipSelection();
        int delayFrequency = currentAudioInfo.delayFrequency;
        float minRange = currentAudioInfo.minRange;
        float maxRange = currentAudioInfo.maxRange;
        bool stopAudioSource = currentAudioInfo.stopAudioSource;

        if(currentDisplayedCharCount % delayFrequency == 0)
        {
            if (stopAudioSource)
            {
                AudioManager.instance.StopAudio();
            }
            AudioManager.instance.PlaySound(soundCLip, minRange, maxRange);
        }
    }
    
    private AudioClip RandomizeClipSelection()
    {
        int randomIndex = Random.Range(0, currentAudioInfo.dialogueSoundClips.Length);
        return currentAudioInfo.dialogueSoundClips[randomIndex];
    }

    private void HideChoices()
    {
        continueText.SetActive(false);
        choiceBoxes.SetActive(false);
    }

    private void HandleTags(List<string> tags)
    {
        foreach (string tag in tags) 
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Invalid tag lengths");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();


            switch (tagKey)
            {
                case SPEAKER_TAG:
                    ParseSpeakerName(tagValue);
                    break;
                case TEXTCOLOR_TAG:
                    ParseTextColor(tagValue);
                    break;
                case ACTION_TAG:
                    ParseAction(tagValue);
                    break;
                case AUDIO_TAG:
                    SetCurrentAudioInfo(tagValue);
                    break;
                default:
                    Debug.LogError("Tag unhandled: " + tag);
                    break;
            }
        }
    }


    private void ParseAction(string actionTag)
    {
        if(actionTag == "giveItem")
        {
            interacitve.SetCanGiveItem();

        }
    }

    private void ParseSpeakerName(string speakerName)
    {
        if (speakerName == "none")
        { speakerNameText.text = string.Empty; }
        else
        { speakerNameText.text = speakerName; }

        switch (speakerName) 
        {
            case "none":
                speakerPanel.SetActive(false);
                break;
            default:
                speakerPanel.SetActive(true);
                break;
        }
    }


    // kind of a stupid way to do it, but whatever
    // overloaded method this one for the speaker text
    private void ParseTextColor(string textColor)
    {
        switch (textColor)
        {
            case "white":
                speakerNameText.color = Color.white;
                dialogueText.color = Color.white;
                break;
            case "light blue":
                speakerNameText.color = new Color(0.796f, 0.858f, 0.988f);
                dialogueText.color = new Color(0.796f, 0.858f, 0.988f);
                break;
            case "orange":
                speakerNameText.color = new Color(0.89f, 0.627f, 0.4f);
                dialogueText.color = new Color(0.89f, 0.627f, 0.4f);
                break;
            case "dark green":
                speakerNameText.color = new Color(0.215f, 0.58f, 0.431f);
                dialogueText.color = new Color(0.215f, 0.58f, 0.431f);
                break;
            case "green":
                speakerNameText.color = new Color(0.315f, 0.645f, 0.148f);
                dialogueText.color = new Color(0.415f, 0.745f, 0.188f);
                break;
            case "grey":
                speakerNameText.color = new Color(0.607f, 0.678f, 0.717f);
                dialogueText.color = new Color(0.607f, 0.678f, 0.717f);
                break;
            case "purple":
                speakerNameText.color = new Color(0.67f, 0.255f, 0.83f);
                dialogueText.color = new Color(0.65f, 0.4f, 0.8f);
                break;
            default:
                Debug.Log("Default text to white");
                speakerNameText.color = Color.white;
                dialogueText.color = Color.white;
                break;
        }
    }


    private void DisplayChoices()
    {
        //Debug.Log("Displaying the choice");
        // Choice comes from Ink, determiend by the Story selected
        List<Choice> currentChoices = currentStory.currentChoices;

        // Checking if the number of choices is greater than the number of UI elements supported
        if(currentChoices.Count > choicesSelections.Length) 
        {
            Debug.Log("you have too many choices for the UI!");
        }

        // iterate through the list of currentChoices as per the Story selected in dialogue
        // populate the buttons and text appropriately
        int i = 0;
        foreach(Choice choice in currentChoices) 
        {
            choicesSelections[i].gameObject.SetActive(true);
            choicesText[i].text = choice.text;
            i++;
        }

        // find any remaining choices, any UI elements leftover are hidden
        for(int index = i; index < choicesSelections.Length; index++) 
        {
            choicesSelections[index].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }
     

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choicesSelections[0].gameObject);
    }


    public void MakeChoice(int choiceIndex)
    {
        if (canContinueNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            InputManager.instance.RegisterSubmitPressed();
            ContinueDialogue();
        }
    }


    IEnumerator ExitDialogueMode()
    {

        yield return new WaitForEndOfFrame();
        //print("exiting dialogue");
        // As a way for outside classes to know if dialogue has ended
        // resets the field
        endOfDialogue = true;


        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;

        dialogueBox.SetActive(false);
        dialogueText.text = string.Empty;
        dialogueText.color = Color.white;

        SetCurrentAudioInfo(defaultAudioInfo.id);
    }


    public Ink.Runtime.Object GetVariableState(string name)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(name, out variableValue);
        if(variableValue == null)
        {
            Debug.LogWarning("Ink variable was null: " + variableValue);
        }

        return variableValue;
    }


    private IEnumerator ResetDialogue() 
    {
        endOfDialogue = false;
        yield return new WaitForSeconds(0.5f);
    }
}
