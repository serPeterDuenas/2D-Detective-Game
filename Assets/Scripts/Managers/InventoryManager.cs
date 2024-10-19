using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }

    [Header("Player's inventory and UI")]
    // the inventory for the player;
    [SerializeField] private InventoryObject inventory;

    [SerializeField] private GameObject inventoryUI;

    public bool inventoryOpen { get; private set; } = false;



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
    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);
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




    // Perhaps pause time when inventory is open
    private void SetInventoryActive()
    {
        // If already open, then close
        if (inventoryOpen == true)
        {
            inventoryUI.SetActive(false);
            inventoryOpen = false;
            Time.timeScale = 1f;
        }
        // Otherwise, if not open then open the panel
        else if (inventoryOpen == false)
        {
            inventoryUI.SetActive(true);
            inventoryOpen = true;
            Time.timeScale = 0f;
        }
    }


    public void AddItem(Item1 item)
    {
        Debug.Log("Sprite is: " + item.sprite + "Item desc is " + item.itemDescription
            + "item name is: " + item.itemName);
    }


    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
