using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Default Object", menuName = "Inventory System/Items/Default")]
// Extends from abstract ItemObject class, implements default values for Item
public class DefaultItem : ItemObject
{
    // constructing default values whenever default Item is created
    public void Awake()
    {
        type = ItemType.Default;
    }
}
