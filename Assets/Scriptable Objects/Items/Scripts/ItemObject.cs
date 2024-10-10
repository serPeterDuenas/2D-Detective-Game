using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Enum to hold the type of item. Only 2 types of items in game: 
// Motivation items and murder weapons
public enum ItemType
{
    Motivation,
    Weapon,
    Default

}

public abstract class ItemObject : ScriptableObject
{
    // to display item in inventory
    public GameObject prefab;

    // to store the type of item this particular object holds
    public ItemType type;

    // to describe the item held
    [TextArea(15, 20)]
    public string desc;
}
