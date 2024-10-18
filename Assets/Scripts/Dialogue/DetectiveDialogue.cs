using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DetectiveDialogue : Interactive, Interactable
{
    // Detective specific dialogue, if other Interactives also seem to use this,
    // then I'll add it to parent class

    [Header("Additional INK JSON")]
    [SerializeField] private TextAsset endDialogueText;

    private int endChoice = 0;

    private bool endingReady = false;

    string getEndingChoice;

    // Update is called once per frame


    void Update()
    {


        // waiting to listen for player choice with dictionary key
        // endingChoice
        getEndingChoice =
               ((Ink.Runtime.StringValue)
               DialogueManager.instance.GetVariableState("endingChoice")).value;

     
        if(endingReady) 
        {
            GetChoiceEnding();
            
        }
        
    


        if (GameManager.instance.AllItemsCollected && !endingReady)
        {
            EndGameDialogue();
        }
        else
            return;
        // checks if at the end of dialogue, and if also the active obj in dialogue
        if (DialogueManager.instance.endOfDialogue && isInteracting)
        {
            GiveItem();
            isInteracting = !isInteracting;
        }
        else
            return;


    }

    public override void EnterDialogue()
    {
        isInteracting = true;
        if (!endingReady)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON);
            //dialogueEntered++;
        }
        else if (endingReady)
        {
            DialogueManager.instance.EnterDialogueMode(endDialogueText);

           
         


        }

    }

    private void EndGameDialogue()
    {
        endingReady = true;
        //print("This fires if all items are collected");

        
        // Function fires when all Items have been collected. 
        // Does new dialogue, then 
    }

    private void GetChoiceEnding()
    {
        if (getEndingChoice == "Stay")
        {
            endingReady = false;
            Debug.Log("player chose to stay");
        }
        else if (getEndingChoice == "Solve")
        {
            endingReady = false;
            Debug.Log("player chose to solve the puzzle");
            SwitchRooms();
        }
        else
        {
            endingReady = false;
            Debug.Log("Chose nothing");
            return;
        }
    }

    private void SwitchRooms()
    {
        if(DialogueManager.instance.endOfDialogue)
        {
            CameraControl.instance.SetCamera();
            GameManager.instance.GoToPuzzleSection();
        }
            
    }
}
