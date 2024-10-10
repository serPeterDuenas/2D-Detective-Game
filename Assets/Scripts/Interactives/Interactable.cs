using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Reference to PlayerInventory")]
    [SerializeField] private InventoryObject playerInventory;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Interaction sound")]
    [SerializeField] private AudioClip soundClip;

    [Header("Item, if any")]
    [SerializeField] private bool canGiveItem = false;
    public ItemObject item;


    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {
        if (DialogueManager.instance.endOfDialogue && canGiveItem)
        {
            GiveItem();
            canGiveItem=false;
        }
        else
            return;
    }


    public void PlaySound()
    {
        SoundManager.instance.PlaySound(soundClip);
    }


    public void EnterDialogue()
    {
        DialogueManager.instance.EnterDialogueMode(inkJSON);
    }


    private void GiveItem()
    {
        Debug.Log("giving item");
        playerInventory.AddItem(item, 1);
    }

}
