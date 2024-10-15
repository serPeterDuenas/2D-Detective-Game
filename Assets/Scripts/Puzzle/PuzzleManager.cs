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

    private bool puzzleCompleted = false;
    private int correctSlots = 0;

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

        if(puzzleCompleted)
        {
            // Activate UI element for End game
            // End game here

            Debug.Log("You won the game!"); ;
       
        }
        else
        {
            return;
        }
    }



    private void MakeButtonActive()
    {
        button.SetActive(true);
    }



    public void ParseSelections()
    {
        foreach (var (key, values) in PuzzlePieces)
        {
            if(key == "Bianca" && values == SlotType.Suspect)
            {
                correctSlots++;
                continue;
            }
            else if(key == "Machete" && values == SlotType.Weapon)
            {
                correctSlots++;
                continue;
            }
            else if(key == "Watch" && values == SlotType.Motivation)
            {
                correctSlots++;
                continue;
            }
            else
            {
                correctSlots = 0;
            }
        }

        Debug.Log(correctSlots);
        if(correctSlots == 3)
        {
            puzzleCompleted = true;
        }
    }



    // Takes in the piece that's been added and to which slot
    // Increments field
    public void AddSelectedPiece(string pieceName, SlotType slotType)
    {
        Debug.Log("Piece has been placed, ID as follows");
        Debug.Log(pieceName);
        Debug.Log(slotType);

        PuzzlePieces.Add(pieceName, slotType);
        IncrementSlot();

    }


    // If piece removed, then delete from Dictionary 
    // Decrement from field
    public void DeleteSelectedPiece(string pieceName, SlotType slotType)
    {
        Debug.Log("Piece has been deleted from Dictioanry, ID as follows");
        Debug.Log(pieceName);
        Debug.Log(slotType);

        PuzzlePieces.Remove(pieceName);
        DecrementSlot();

    }

    // This method adds to Dictionary, and increments field to know if at any point
    // There are exactly 3 filled slots
    private void IncrementSlot()
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
