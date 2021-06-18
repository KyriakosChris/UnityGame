using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    /* 
    It manages the Audio that is playing. It can play many audio at the same time.
     * */
    void Awake()
    {
        //init the Sounds at the start from the list of sounds
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    // Always Play The Theme Song 
    void Start()
    {
        Play("Theme");
    }
    //Plays The song that has the given name.
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        if (!s.source.isPlaying)
            s.source.Play();
    }
    //Stop playing The song that has the given name.
    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        if(s.source.isPlaying)
            s.source.Stop();
    }
}
