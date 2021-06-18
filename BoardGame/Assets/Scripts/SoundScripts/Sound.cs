using UnityEngine.Audio;
using UnityEngine;

/*
 Some variables that helps to set up each audio in the list. The songs are added in the inspector.
 */
[System.Serializable]
public class Sound
{
    
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
