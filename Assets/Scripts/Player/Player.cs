using System.Collections;
using System.Collections.Generic;
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


    // after entering dialogue, receive item through this method
    public static void AddItem(Item other)
    {
        var item = other;
        if(item)
        {
            //inventory.AddItem(item.item, 1);
        }
    }
}
