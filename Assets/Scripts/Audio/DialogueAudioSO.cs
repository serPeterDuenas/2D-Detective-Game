using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueAudioInfo", menuName = "ScriptableObjects/DialogueAudioInfoSO", order = 1)]
public class DialogueAudioSO : ScriptableObject
{
    public string id;
    public AudioClip[] dialogueSoundClips;
    public bool stopAudioSource;
    [Range(1, 15)]
    public int delayFrequency;
    [Range(-1f, 3f)]
    public float minRange;
    [Range(-1f, 3f)]
    public float maxRange;
}
