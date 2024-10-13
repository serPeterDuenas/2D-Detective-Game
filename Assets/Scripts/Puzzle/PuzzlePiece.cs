using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public enum PieceType
    {
        Weapon,
        Motivation,
        Suspect
    }

    public PieceType type;

    [SerializeField] private float distanceFromSlot;

    private bool isHolding = false;
    private bool placed = false;
    private Vector2 offSet, originalPos;

    private PuzzleSlot thisSlot;
    [SerializeField] private Transform motivationSlot;
    [SerializeField] private Transform weaponSlot;
    [SerializeField] private Transform suspectSlot;

    private void Awake()
    {
        originalPos = transform.position;
    }


    void Update()
    {
       // If this piece is already held and in place, then do nothing, otherwise
       // continue the rest of loop
       if(!isHolding)
        {
            return;
        }

        Vector2 mousePos = GetMousePos();


        // updates the position of this object minus the offset to the mouse position
        transform.position = mousePos - offSet;
    }




    private void OnMouseDown()
    {
        isHolding = true;

        // offSet = the returned mouse position minus the current object position
        offSet = GetMousePos() - (Vector2)transform.position;
    }


    private void OnMouseUp()
    {

        // This is brute force as fuck, but imma just do it this way
        CheckPiecePosition();
        isHolding = false;

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PuzzleSlot")
        {
            thisSlot = collision.GetComponent<PuzzleSlot>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PuzzleSlot")
        {
            thisSlot = collision.GetComponent<PuzzleSlot>();

            // If this piece was already placed, and you are clearing it out of the box,
            // If it was placed, then make the slot available
            if (placed)
            {
                placed = false;
                thisSlot.MakeSlotAvailable();
            }
            else
            {
                return;
            }
        }
    }


   


    private void CheckPiecePosition()
    {
        if(CheckAvailable() && !placed)
        {
           CheckDistance();
        }
        else if(placed)
        {
            CheckDistance();
        }
        else
        {
           ResetPosition();
        }
    }
    

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, motivationSlot.transform.position) <= distanceFromSlot)
        {
            transform.position = motivationSlot.transform.position;
            thisSlot.MakeSlotUnavailable();
            placed = true;
            isHolding = false;
        }
        else if (Vector2.Distance(transform.position, weaponSlot.transform.position) < distanceFromSlot)
        {
            transform.position = weaponSlot.transform.position;
            thisSlot.MakeSlotUnavailable();
            placed = true;
            isHolding = false;
        }
        else if (Vector2.Distance(transform.position, suspectSlot.transform.position) < distanceFromSlot)
        {
            transform.position = suspectSlot.transform.position;
            thisSlot.MakeSlotUnavailable();
            placed = true;
            isHolding = false;
        }
    }

    private bool CheckAvailable()
    {
        if (thisSlot != null && thisSlot.GetSlot())
        {
            return thisSlot.GetSlot();
        }
        else
            return false;
    }

    private void ResetPosition()
    {
        transform.position = originalPos;
        placed = false;
        isHolding = false;
    }


    // Gets mouse position relative to the Camera's world point
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
