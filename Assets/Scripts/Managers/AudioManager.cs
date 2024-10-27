using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        //gatheredAllItems = false;
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            return;
        }
    }


    public void PlaySound(AudioClip audioClip, float minRange, float maxRange)
    {
        audioSource.pitch = Random.Range(minRange, maxRange);
        audioSource.PlayOneShot(audioClip);
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
