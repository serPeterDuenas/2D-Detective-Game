using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool playerInRange = false;

    // This is such a silly work around, but this will just work for now, I think
    private Interactable trigger;

    

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (playerInRange && !DialogueManager.instance.dialogueIsPlaying)
            {
                // grabs InputManager's instance, and listens for if the input for interact was pressed
                if (InputManager.instance.GetInteractPressed())
                {
                    trigger.EnterDialogue();
                    trigger.PlaySound();
                }
            }
            else
                return;
        }
        else
            return;

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            Debug.Log("Entered an interactable hitbox");
            trigger = collision.GetComponent<Interactable>();
            playerInRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }
}
