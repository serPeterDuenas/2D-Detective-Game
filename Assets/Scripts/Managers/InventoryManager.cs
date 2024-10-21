using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }
    [SerializeField] private ItemSlots[] itemSlots;


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
        if (InputManager.instance.GetInventoryPressed() && !DialogueManager.instance.dialogueIsPlaying)
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
        for(int i = 0; i < itemSlots.Length; i++) 
        {
            if (itemSlots[i].isFull == false)
            {
                itemSlots[i].AddItem(item);
                return;
            }
        }
    }

    public void DeselecteShader()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].thisItemSelected = false;
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
