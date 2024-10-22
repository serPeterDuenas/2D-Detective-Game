using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractive : DefaultInteractive
{

    [Header("Additional INK JSON")]
    [SerializeField] private TextAsset afterTakenItem;

    [SerializeField] private int timesInteractedWith = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting)
        {
            UpdateDialogue();
        }
        else
            return;
    }


    private void UpdateDialogue()
    {
        timesInteractedWith++;

        if(timesInteractedWith >= 1)
        {
            DialogueManager.instance.EnterDialogueMode(afterTakenItem);
        }
    }
}
