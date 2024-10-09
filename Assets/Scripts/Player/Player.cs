using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{

    // the inventory for the player;
    public InventoryObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        if(collision.tag == "Interactable" && item)
        {
            Debug.Log("added item");
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }


    // after entering dialogue, receive item through this method
    public static void AddItem(Item other)
    {
        var item = other;
        if(item)
        {
            //inventory.AddItem(item.item, 1);
        }
    }


    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
