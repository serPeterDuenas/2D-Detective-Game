using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using static Unity.VisualScripting.Member;

public class GameManager : MonoBehaviour
{
    [Header("Holds GameObjects of the play room that is active/to be active")]
    [SerializeField] private GameObject MainRoom;
    [SerializeField] private GameObject PuzzleRoom;
    [SerializeField] private GameObject PuzzleUI;

    [Header("The # of items necessary to progress the game")]
    [SerializeField] private int totalItemsNeeded;
    public bool AllItemsCollected { get; private set; }
    public int ItemsCollected { get; private set; }

    public static GameManager instance { get; private set; }


   


    // delegate for when all items have been collected
    //public delegate void OnItemsCollected();
    public event Action OnItemsCollected;

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

    private void Start()
    {
        ItemsCollected = 0;
    }


    void Update()
    {
       

        // this has to get updated
        if(ItemsCollected == totalItemsNeeded)
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






     
   


}
