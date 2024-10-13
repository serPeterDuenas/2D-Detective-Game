using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public enum SlotType
    {
        Weapon,
        Motivation,
        Suspect
    }

    public SlotType type;

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


    public void MakeSlotUnavailable()
    {
        slotAvailable = false;
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
