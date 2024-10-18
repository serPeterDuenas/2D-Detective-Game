using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using static Unity.VisualScripting.Member;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject MainRoom;
    [SerializeField] private GameObject PuzzleRoom;
    [SerializeField] private GameObject PuzzleUI;

    public bool AllItemsCollected { get; private set; }
    public static int ItemsCollected { get; private set; } = 0;

    public static GameManager instance { get; private set; }


    // the inventory for the player;
    [SerializeField] private InventoryObject inventory;

    [SerializeField] private GameObject inventoryUI;

    private bool inventoryOpen = false;


    // delegate for when all items have been collected
    //public delegate void OnItemsCollected();
    public event Action OnItemsCollected;

    void Start()
    {
        inventoryUI.SetActive(false);
    }


    void Update()
    {
        // if input pressed and also inv not already open, then open
        if (InputManager.instance.GetInventoryPressed())
        {

            SetInventoryActive();
        }

        if(ItemsCollected == 2)
        {
            SetAllItemsCollected();
        }
    }



    public void GoToPuzzleSection()
    {
        print("going to puzzle room");
        MainRoom.SetActive(false);
        PuzzleRoom.SetActive(true);
        PuzzleUI.SetActive(true); 
    }


    public void IncrementItemsAdded()
    {
        ItemsCollected++;
    }

    private void SetAllItemsCollected()
    {
        print("Event fired, setting bool AllItemsCollected to True");
        AllItemsCollected = true; 
        ItemsCollected = 0;
    }


    // Perhaps pause time when inventory is open
    private void SetInventoryActive()
    {
        // If already open, then close
        if (inventoryOpen == true)
        {
            inventoryUI.SetActive(false);
            inventoryOpen = false;
        }
        // Otherwise, if not open then open the panel
        else if (inventoryOpen == false)
        {
            inventoryUI.SetActive(true);
            inventoryOpen = true;
        }
    }




    private void Awake()
    {
        //gatheredAllItems = false;
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }
     
   


    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
