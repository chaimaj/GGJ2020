using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour {


    public float scatterInterval = 10;

    public Sound[] themeSounds;

    public Sound[] loopingSounds;

    public Sound[] soundEffects;

    public Sound[] randomScatters;

    public Sound[] collisions;

    public static SoundManager instance = null;

    string prevTheme;
    bool scatters = true;

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

        foreach (Sound s in loopingSounds)
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

        foreach (Sound s in randomScatters)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in collisions)
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
        PlayLoopingThemes(loopingSounds);        
       
        //PlayTheme("TitleTheme");
        //StartCoroutine(FadeIn("TitleTheme", 0.01f, 0.8f));
    }

    private void Update()
    {
        if (scatters)
        {
            StartCoroutine(PlayRandomAtIntervals(randomScatters));
        }
    }


    public void FadeInCaller(string name, float speed, float maxVolume)
    {
        StartCoroutine(FadeIn(name, speed, maxVolume));
    }

    public void FadeOutCaller(string name, float speed)
    {
        StartCoroutine(FadeOut(name, speed));
    }

    
    public void PlayLoopingThemes(Sound[] loops)
    {
        foreach (Sound sound in loops)
        {
            PlayOnce(sound.name, 1f, loops);
        }
    }
    
    public void PlayRandomTheme(Sound[] sounds)
    {
        int index = Random.Range(0, sounds.Length);
        PlaySound(sounds[index].name, sounds);
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

    public void PlaySound(string name, Sound[] sounds)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("No sound named " + name + " !");
            return;
        }
        s.source.Play();
    }

    public void PlayOnce(string name, float pitch, Sound[] sounds)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("No sound named " + name + " !");
            return;
        }
        s.source.pitch = pitch;
        if (!s.source.isPlaying)
            s.source.Play();
    }

    public void StopSound(string name, Sound[] sounds)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
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
        Sound s = Array.Find(themeSounds, sound => sound.name == name);
        s.source.volume = 0;

        while (s.source.volume < maxVolume)
        {
            s.source.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOut(string name, float speed)
    {
        Sound s = Array.Find(themeSounds, sound => sound.name == name);

        while (s.source.volume >= 0)
        {
            s.source.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator PlayRandomAtIntervals(Sound[] sounds)
    {
        scatters = false;
        yield return new WaitForSeconds(scatterInterval);
        scatterInterval = Random.Range(scatterInterval - 2, scatterInterval + 2);
        PlayRandomTheme(sounds);
        scatters = true;
    }
}
