using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource source;
    public static SoundManager instance { get; private set; }



    private void Awake()
    {
        source = GetComponent<AudioSource>();

        if(instance != null && instance != this) 
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PlaySound(AudioClip soundBit)
    {
        source.PlayOneShot(soundBit);
    }
}
