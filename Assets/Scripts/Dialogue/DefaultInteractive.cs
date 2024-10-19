using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractive : Interactive, Interactable
{
    void Update()
    {
        //Debug.Log(DialogueManager.instance.endOfDialogue);

        //Debug.Log(canGiveItem);
        if (DialogueManager.instance.endOfDialogue && isInteracting)
        {
            Debug.Log("calling give item from DefaultInteractive");
            GiveItem();
            isInteracting = !isInteracting;
        }
        else
            return;
    }


}
