using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractive : MonoBehaviour, Interactable
{
    [Header("Reference to PlayerInventory")]
    [SerializeField] private InventoryObject playerInventory;


    [Header("Interaction sound")]
    [SerializeField] private AudioClip soundClip;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    [Header("Item, if any")]
    [SerializeField] private bool canGiveItem = false;
    [SerializeField] private ItemObject item;

    private bool isInteracting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks if at the end of dialogue, and if also the active obj in dialogue
        if (DialogueManager.instance.endOfDialogue && isInteracting)
        {
            Debug.Log("calling give item from defaultineractive");
            GiveItem();
            isInteracting = !isInteracting;
        }
        else
            return;
    }


    public void EnterDialogue()
    {
        DialogueManager.instance.EnterDialogueMode(inkJSON);
        Debug.Log("Enter dialogue from Default script");

        isInteracting = true;
        //throw new System.NotImplementedException();
    }

    public void PlaySound()
    {
        SoundManager.instance.PlaySound(soundClip);
        Debug.Log("Play sound from default scrip");
       // throw new System.NotImplementedException(); 
    }


    private void GiveItem()
    {
        Debug.Log("calling GiveItem from default class");
        if (canGiveItem)
        {
            playerInventory.AddItem(item, 1);
            Debug.Log("give item from default class");
            canGiveItem = false;
        }
        else
            return;
    }
}