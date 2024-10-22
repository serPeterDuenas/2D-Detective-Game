using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractive : DefaultInteractive
{

    [Header("Additional INK JSON")]
    [SerializeField] private TextAsset afterTakenItem;

    [SerializeField] private int timesInteractedWith = 0;


    public override void EnterDialogue()
    {
        isInteracting = true;
        timesInteractedWith++;
        DialogueManager.instance.EnterDialogueMode(inkJSON);

        if (timesInteractedWith > 1)
        {
            DialogueManager.instance.EnterDialogueMode(afterTakenItem);
        }
    }
}
