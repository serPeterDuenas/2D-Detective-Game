using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }
    public float textSpeed = 0.08f;
    public TextMeshProUGUI textContainer;
    public GameObject dialogueBox;

    [SerializeField] private Queue<string> queuedLines;


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

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        queuedLines = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation");

        queuedLines.Clear();

        foreach(string line in dialogue.lines)
        {
            queuedLines.Enqueue(line);
            //Debug.Log(lines.Peek());
        }

        dialogueBox.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        Debug.Log(queuedLines.Count);
        if(queuedLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentLine = queuedLines.Dequeue();
        Debug.Log(currentLine);
        StopAllCoroutines();
        StartCoroutine(TypeLine(currentLine));
    }
    

    IEnumerator TypeLine(string currentLine)
    {
        textContainer.text = string.Empty;
        foreach(char c in currentLine.ToCharArray())
        {
            textContainer.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    public void EndDialogue()
    {
        Debug.Log("end of conversation");
        InteractiveObj.isInDialogue = false;
        dialogueBox.SetActive(false);
    }
}
