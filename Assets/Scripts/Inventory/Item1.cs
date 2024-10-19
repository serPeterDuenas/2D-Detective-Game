using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item1", menuName = "Inventory/Item")]
public class Item1 : ScriptableObject
{
    // item properties needed to display in Inventory
    public string itemName;

    [TextArea(15, 20)]
    public string itemDescription;


    public Sprite sprite;
}
