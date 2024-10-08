using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool insideZone = false;
    private InteractiveObj obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check to see if game is paused OR if in dialogue
        if (PauseMenu.isPaused == false ^ InteractiveObj.isInDialogue == true)
        {
            if (insideZone && Input.GetKeyDown("e"))
            {
                Debug.Log("Interacted with object");
                obj.ReturnMessage();
            }
        }
        else
            return;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            obj = collision.GetComponent<InteractiveObj>();
            Debug.Log("Entered interaction zone");
            insideZone = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exiting zone");
        insideZone = false;
    }
}
