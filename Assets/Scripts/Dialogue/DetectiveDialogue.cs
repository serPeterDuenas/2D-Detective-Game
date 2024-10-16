using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveDialogue : Interactive, Interactable
{
    // Detective specific dialogue, if other Interactives also seem to use this,
    // then I'll add it to parent class

    [Header("Additional INK JSON")]
    [SerializeField] private TextAsset endDialogueText;

    private int dialogueEntered = 0;

    
    


    // Update is called once per frame
    void Update()
    {
        // checks if at the end of dialogue, and if also the active obj in dialogue
        if (DialogueManager.instance.endOfDialogue && isInteracting)
        {
            GiveItem();
            isInteracting = !isInteracting;
        }
        else
            return;
    }

    public void EnterDialogue()
    {
        isInteracting = true;
        if (dialogueEntered == 0)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON);
            dialogueEntered++;
        }
        else if (dialogueEntered >= 1)
        {
            DialogueManager.instance.EnterDialogueMode(endDialogueText);
        }
       
    }

    public void PlaySound()
    {
        SoundManager.instance.PlaySound(soundClip);
    }


    private void GiveItem()
    {
        if (canGiveItems)
        {
            playerInventory.AddItem(item, 1);
            Debug.Log("give item from detective class");
            canGiveItems = false;
        }
        else
            return;
    }

    private void EndGameDialogue()
    {
        // Function fires when all Items have been collected. 
        // Does new dialogue, then 
    }
}
