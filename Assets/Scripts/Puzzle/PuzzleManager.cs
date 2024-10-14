using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // an increment for the slots filled, once at 3, should allow
    // the button to then appear and become interactable
    public static int filledSlots { get; private set; }
    private Dictionary<string, SlotType> puzzlePieces = new();
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
        puzzlePieces.Add("Machete", SlotType.Weapon);
        puzzlePieces.Add("Bianca", SlotType.Suspect);
        puzzlePieces.Add("Watch", SlotType.Motivation);
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
        int correctSlots = 0;
        foreach(var (key, value) in puzzlePieces)
        {
            if(key == "Bianca" && value == SlotType.Suspect) 
            {
                correctSlots++;
                Debug.Log("One selection is correct");
            }
            if(key == "Machete" && value == SlotType.Weapon)
            {
                correctSlots++;
                Debug.Log("One selection is correct");

            }
            if(key == "Watch" && value == SlotType.Motivation)
            {
                correctSlots++;
                Debug.Log("One selection is correct");
                Debug.Log(correctSlots);
            }
            else
            {
                Debug.Log("The selections are not correct");
                correctSlots = 0;
                Debug.Log(correctSlots);
            }
            Debug.Log(key + ": " + value);
        }
        Debug.Log("Checking player's selection after hitting button");
        //CheckCorrect();
    }


    public void GetSelectedPiece(PieceType pieceType, SlotType slotType)
    {
        Debug.Log(pieceType);
        Debug.Log(slotType);
    }


    public void IncrementSlot()
    {
       
        filledSlots++;
        Debug.Log("Filled slots: " + filledSlots);
    }

    public void DecrementSlot()
    {
        
        filledSlots--;
        Debug.Log("Filled slots: " + filledSlots);
    }
}
