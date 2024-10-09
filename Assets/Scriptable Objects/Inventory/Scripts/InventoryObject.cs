using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{

    // a list of InventorySlot, class which holds ItemObjects and quantity of it
    public List<InventorySlot> Container = new List<InventorySlot> ();


    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;

        Debug.Log("Adding item to inventory");

        // loop through Container to find if Item has already been added
        for (int i = 0; i < Container.Count; i++) 
        {
            if (Container[i].item == _item) 
            {
                // if there is already this item, then call method AddAmount to increase quantity
                Container[i].AddAmount(_amount);
                Debug.Log("Already in inventory, adding");
                hasItem = true;
                break;
            }
            // If this item is not already in Container, then evoke InventorySlot constructor to add
            if(!hasItem)
            {
                Debug.Log("adding new item to inventory");
                Container.Add(new InventorySlot(_item, _amount));
            }

        }
    }
}


// To allocate the slot for an ItemObject, and holds the quantity in that slot
[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    // Whenever a new slot is created, evoke constructor to get the ItemObject type and the quantity
    // of said item
    public InventorySlot(ItemObject _item, int _amount)
    {
        Debug.Log("Adding inventory slot to invObj");
        item = _item;
        amount = _amount;
    }


    public void AddAmount(int quantity)
    {
        Debug.Log("adding amount to slot");
        amount += quantity;
    }
}