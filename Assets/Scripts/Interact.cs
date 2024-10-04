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
        if (insideZone && Input.GetKeyDown("space"))
        {
            Debug.Log("Interacted with object");
            obj.ReturnMessage();
        }
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
