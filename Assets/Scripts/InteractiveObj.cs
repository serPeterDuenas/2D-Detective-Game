using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObj : MonoBehaviour
{
    [SerializeField] private string GiveMessage = "Hello";
    [SerializeField] private AudioClip soundClip;
    [SerializeField] private bool isInDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReturnMessage()
    {
        if (!isInDialogue) 
        {
            isInDialogue = true;
            Debug.Log(GiveMessage);
            SoundManager.instance.PlaySound(soundClip);
        }
       
    }
}
