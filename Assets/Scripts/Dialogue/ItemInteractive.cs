using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemInteractive : Interactive, Interactable
{

    [Header("Additional dialogue")]
    [SerializeField] private TextAsset afterTakenItem;
    [SerializeField] private int timesInteractedWith = 0;

    [Header("Sprite to replace after item taken")]
    [SerializeField] private GameObject newSprite;


    private void Start()
    {
        newSprite.SetActive(false);
    }


    private void Update()
    {
        if (DialogueManager.instance.endOfDialogue && isInteracting)
        {
            GiveItem();
            isInteracting = !isInteracting;
        }
        else
            return;

        if(DialogueManager.instance.endOfDialogue) 
        {
            newSprite.SetActive(true);
        }
    }


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
