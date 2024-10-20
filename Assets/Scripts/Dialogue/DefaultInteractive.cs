using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractive : Interactive, Interactable
{
    void Update()
    {
        if (DialogueManager.instance.endOfDialogue && isInteracting)
        {
            GiveItem();
            isInteracting = !isInteracting;
        }
        else
            return;
    }


}
