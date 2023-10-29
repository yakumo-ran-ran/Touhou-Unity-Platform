using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEditor.Tilemaps;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (var sound in sounds)
        {
            sound.source=gameObject.AddComponent<AudioSource>();
            sound.source.clip=sound.clip;
            sound.source.volume=sound.volume;
            sound.source.pitch=sound.pitch;
            sound.source.loop=sound.loop;
        }
    }
    public void Play(string name)
    {
        Sound s=Array.Find(sounds,sound=>sound.name==name); 
        if(s==null)
        {
            return;
        }
        
        s.source.Play();
    }
    private void Start()
    {
        Play("Theme");
        Debug.Log("Played");
    }
}
