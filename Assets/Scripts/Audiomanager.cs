using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager Instance;
    public Sound[] musicsounds, sfxsounds;
    public AudioSource musicsource, sfxsource;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        PlayMusic("banger");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicsounds, x => x.name == name);
        if (s==null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicsource.clip = s.clip;
            musicsource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxsounds, x => x.name == name);
        if (s == null)
        {
         Debug.Log("Sound not found");
        }
        else
        {
            sfxsource.PlayOneShot(s.clip);
        }
    }
    public void Togglemusic()
    {
        musicsource.mute = !musicsource.mute;

    }
    public void Togglesfx()
    {
        sfxsource.mute = !sfxsource.mute;
    }
    public void Musicvolume(float Music)
    {
        musicsource.volume = Music;
    }
    public void SFXvolume(float sfx)
    {
        sfxsource.volume = sfx;
    }

}
