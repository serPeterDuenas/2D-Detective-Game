using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameRoom;
    public bool gatheredAllItems { get; private set; }


    public static GameManager instance { get; private set; }


    // the inventory for the player;
    [SerializeField] private InventoryObject inventory;

    [SerializeField] private GameObject inventoryUI;

    private bool inventoryOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);
    }

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
        gatheredAllItems = false;
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }
     
    // Update is called once per frame
    void Update()
    {
        // if input pressed and also inv not already open, then open
        if (InputManager.instance.GetInventoryPressed())
        {

            SetInventoryActive();
        }
    }


    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
