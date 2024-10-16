using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private float textSpeed = 0.07f;
    [SerializeField] private TextMeshProUGUI textContainer;
    [SerializeField] private GameObject dialogueBox;


    [Header("Choices UI")]
    // array of gameobjects to store the buttons on the Canvas
    [SerializeField] private GameObject[] choicesSelections;
    private TextMeshProUGUI[] choicesText;


    private Story currentStory;
    public static DialogueManager instance { get; private set; }
    public bool dialogueIsPlaying { get; private set; }


    // To be used to check if can give item to player
    public bool endOfDialogue { get;  set; }

    //[SerializeField] private Queue<string> queuedLines;
    

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
    }


    private void Update()
    {
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }
        //if (endOfDialogue)
       // {
        //    Debug.Log("reached end of dialogue");
       // }
       // else
         //   return;


        // listen for if player pressed "interact" to continue with dialogue
        if (InputManager.instance.GetSubmitPressed())
        {
            //Debug.Log("Pressed 'submit' while in dialogue");
            ContinueDialogue();
        }

    }


    // Begins dialogue, taking in a JSON TextAsset to create a new Story
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        // creates an instance of Story using TextAsset argument
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        endOfDialogue = false;
        dialogueBox.SetActive(true);



        ContinueDialogue();
    }



    private void ContinueDialogue()
    {
        // If there are any lines in the Story to be played, set the text to the current line
        if (currentStory.canContinue)
        {
            // set text for current dialogue lines
            textContainer.text = currentStory.Continue();

            // diplay choices if there are any
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }



    private void DisplayChoices()
    {
        Debug.Log("Displaying the choice");
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
        currentStory.ChooseChoiceIndex(choiceIndex);
    }


    private void ExitDialogueMode()
    {
        // As a way for outside classes to know if dialogue has ended
        // resets the field
        endOfDialogue = true;
        //StartCoroutine(ResetDialogue());


        dialogueIsPlaying = false;

        dialogueBox.SetActive(false);
        textContainer.text = string.Empty;
    }


    private IEnumerator ResetDialogue() 
    {
        endOfDialogue = false;
        yield return new WaitForSeconds(0.5f);
    }
}
