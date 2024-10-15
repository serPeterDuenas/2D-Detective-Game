using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SlotType
{
    Weapon,
    Motivation,
    Suspect
}

public class PuzzleSlot : MonoBehaviour
{
    

    [SerializeField] private SlotType type;

   [SerializeField] bool slotAvailable = true;


    // Start is called before the first frame update
    void Start()
    {
        slotAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
    }


    public SlotType GetSlotType()
    {
        return type;
    }

    public void MakeSlotUnavailable()
    {
        slotAvailable = false;
        SendManagerInfo();
    }    


    private void SendManagerInfo()
    {

    }


    public void MakeSlotAvailable()
    {
        Debug.Log("Making slot available");
        slotAvailable = true;
    }

    public bool GetSlot()
    { return slotAvailable; }

    public static void CheckPuzzlePiece()
    {

    }
}
