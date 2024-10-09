using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool playerInRange = false;
    private DialogueTrigger obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused == false)
        {
            if (playerInRange && !DialogueManager.instance.dialogueIsPlaying)
            {
                // grabs InputManager's instance, and listens for if the input for interact was pressed
                if (InputManager.instance.GetInteractPressed())
                {
                    obj.EnterDialogue();
                }
            }
            else
                return;
        }
        else
            return;

        //if (PauseMenu.isPaused == false)
        //{
         //   Debug.Log("g")
         //   if (insideZone && Input.GetKeyDown("e"))
          //  {
           //     Debug.Log("Interacted with object");
           // }
        //}
       // else
          //  return;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            obj = collision.GetComponent<DialogueTrigger>();
            playerInRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exiting zone");
        playerInRange = false;
    }
}
