using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Motivation Object", menuName = "Inventory System/Items/Motivation")]

public class MotivationObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Motivation;
    }
}
