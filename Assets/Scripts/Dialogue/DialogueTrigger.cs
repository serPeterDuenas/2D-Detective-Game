using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   // public Dialogue dialogue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Interaction sound")]
    [SerializeField] private AudioClip soundClip;
    //private bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void PlaySound()
    {
        SoundManager.instance.PlaySound(soundClip);
    }


    public void EnterDialogue()
    {
        //DialogueManager.instance.EnterDialogueMode(inkJSON);
    }

}
