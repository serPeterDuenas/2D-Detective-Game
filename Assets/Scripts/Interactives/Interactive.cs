using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{

    [Header("To check if it is this object that is being interacted with")]
    [SerializeField] protected bool isInteracting = false;

   // [Header("Reference to PlayerInventory")]
    //[SerializeField] protected InventoryObject playerInventory;

    [Header("Item, if any")]
    [SerializeField] protected bool canGiveItem = false;
    [SerializeField] protected Item1 item;



    //[Header("Dialogue sound")]
    //[SerializeField] protected AudioClip soundClip;

    [Header("Ink JSON")]
    [SerializeField] protected TextAsset inkJSON;



  



    public virtual void EnterDialogue()
    {
        DialogueManager.instance.EnterDialogueMode(inkJSON, this);
       // Debug.Log("Enter dialogue from Default script");

        isInteracting = true;
        //throw new System.NotImplementedException();
    }

    public virtual void PlaySound()
    {
        //SoundManager.instance.PlaySound(soundClip);
       // Debug.Log("Play sound from default scrip");
        // throw new System.NotImplementedException(); 
    }


    protected virtual void GiveItem()
    {
        //Debug.Log("calling GiveItem from default class");
        if (canGiveItem)
        {
            InventoryManager.instance.AddItem(item);

            //playerInventory.AddItem(item, 1);
           // Debug.Log("give item from default class");
            canGiveItem = false;
            IncrementItem();
        }
        else
            return;
    }


    public void SetCanGiveItem()
    {
        canGiveItem = true;
    }


    // If this interactive object gives an item ,then increment the GameManager
    private void IncrementItem()
    {
       GameManager.instance.IncrementItemsAdded();
        Debug.Log(GameManager.instance.ItemsCollected);
    }

}
