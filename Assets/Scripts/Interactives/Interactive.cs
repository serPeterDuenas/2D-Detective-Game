using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [Header("Reference to PlayerInventory")]
    [SerializeField] protected InventoryObject playerInventory;

    [Header("Item, if any")]
    [SerializeField] protected bool canGiveItems = false;
    [SerializeField] protected ItemObject item;


    [Header("Interaction sound")]
    [SerializeField] protected AudioClip soundClip;

    [Header("Ink JSON")]
    [SerializeField] protected TextAsset inkJSON;


    [Header("To check if it is this object that is being interacted with")]
    [SerializeField] protected bool isInteracting = false;

}
