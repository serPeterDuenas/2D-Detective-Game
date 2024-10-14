using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // an increment for the slots filled, once at 3, should allow
    // the button to then appear and become interactable
    public static int filledSlots { get; private set; }

    // Dictionary that takes in the puzzle piece and which slot it is in
    // Parses if the Dictionary is in correct order, then ends game 
    private Dictionary<string, SlotType> PuzzlePieces = new();


    [SerializeField] private GameObject button;

    public static PuzzleManager instance { get ; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if the slots are not full, then keep inactive
        if (filledSlots != 3)
        {
            button.SetActive(false);
            return;
        }
        else
        {
            MakeButtonActive();
        }
    }



    private void MakeButtonActive()
    {
        button.SetActive(true);
    }



    public void ParseSelections()
    {
        //Debug.Log("Checking player's selection after hitting button");
        //CheckCorrect();
    }


    public void GetSelectedPiece(string pieceName, SlotType slotType)
    {
        Debug.Log("Piece has been placed, ID as follows");
        Debug.Log(pieceName);
        Debug.Log(slotType);
    }


    public void IncrementSlot()
    {
       
        filledSlots++;
       // Debug.Log("Filled slots: " + filledSlots);
    }

    public void DecrementSlot()
    {
        
        filledSlots--;
        //Debug.Log("Filled slots: " + filledSlots);
    }
}
