using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   // public Dialogue dialogue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    //private bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerInRange && !DialogueManager.instance.dialogueIsPlaying)
       // {
            // grabs InputManager's instance, and listens for if the input for interact was pressed
          //  if(InputManager.instance.GetInteractPressed())
           // {
           ////    DialogueManager.instance.EnterDialogueMode(inkJSON);
           // }
       // }
       // else
           // return;
    }


    public void EnterDialogue()
    {
        DialogueManager.instance.EnterDialogueMode(inkJSON);
    }

   // private void OnTriggerEnter2D(Collider2D collision)
   // {
    //    if (collision.tag == "Player")
    //    {
    //        playerInRange = true;
    //    }
   // }

   // private void OnTriggerExit2D(Collider2D collision)
   // {
    //    if (collision.tag == "Player")
    //    {
    //        playerInRange = false;
    //    }
   // }


    //public void TriggerDialogue()
    //{
   //     DialogueManager.instance.StartDialogue(dialogue);
   // }
}
