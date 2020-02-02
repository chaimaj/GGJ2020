using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class SoundManager : MonoBehaviour {


    public Sound[] themeSounds;
    // Use this for initialization

    public Sound[] soundEffects;

    public Sound[] birds;

    public static SoundManager instance = null;
    public static bool keepFadingIn = true;
    public static bool keepFadingOut = true;

    string prevTheme;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in themeSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in soundEffects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in birds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }


    }

    private void Start()
    {

       
        PlayTheme("TitleTheme");
        StartCoroutine(FadeIn("TitleTheme", 0.01f, 0.8f));
    }


    public void FadeInCaller(string name, float speed, float maxVolume)
    {
        StartCoroutine(FadeIn(name, speed, maxVolume));
    }

    public void FadeOutCaller(string name, float speed)
    {
        StartCoroutine(FadeOut(name, speed));
    }

    

    
    public void PlayRandomTheme(Sound[] sounds)
    {

    }


    public void PlayTheme(string name)
    {        
        foreach (Sound s in themeSounds)
        {
            if (s.name == name)
            {
                if (!s.source.isPlaying)
                {
                    s.source.Play();
                    prevTheme = name;
                    StartCoroutine(FadeIn(name, 0.01f, 0.3f));
                }
            }
            else
            {
                s.source.Stop();
            }
        }       
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(soundEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("No sound named " + name + " !");
            return;
        }
        s.source.Play();
    }

    public void PlayOnce(string name, float pitch)
    {
        Sound s = Array.Find(soundEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("No sound named " + name + " !");
            return;
        }
        s.source.pitch = pitch;
        if (!s.source.isPlaying)
            s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(soundEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("No sound named " + name + " !");
            return;
        }
        if (s.source.isPlaying)
            s.source.Stop();
    }

    public void ChangeMusicCaller(string newName)
    {
        StartCoroutine(ChangeMusic(newName));
    }

    IEnumerator ChangeMusic(string newName)
    {
        bool start = true;
        Sound s = Array.Find(themeSounds, sound => sound.name == newName);
        if (!s.source.isPlaying)
        {
            while (start)
            {
                if (prevTheme != "")
                    yield return StartCoroutine(FadeOut(prevTheme, 0.03f));
                s.source.Play();
                StartCoroutine(FadeIn(newName, 0.01f, 0.5f));
                start = false;
            }
        }
        else
        {
            while (start)
            {
                yield return StartCoroutine(FadeOut(newName, 0.03f));
                s.source.Play();
                StartCoroutine(FadeIn(newName, 0.01f, 0.5f));
                start = false;
            }
        }
        prevTheme = newName;

    }

    IEnumerator FadeIn(string name, float speed, float maxVolume)
    {
        //keepFadingIn = true;
        //keepFadingOut = false;

        Sound s = Array.Find(themeSounds, sound => sound.name == name);
        s.source.volume = 0;

        while (s.source.volume < maxVolume /*&& keepFadingIn*/)
        {
            s.source.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOut(string name, float speed)
    {
        //keepFadingIn = false;
        //keepFadingOut = true;

        Sound s = Array.Find(themeSounds, sound => sound.name == name);

        while (s.source.volume >= 0 /*&& keepFadingOut*/)
        {
            s.source.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
        //s.source.Stop();
    }
}
