using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public Sound[] sounds; // Array of sounds to use in the editor
    public static Audiomanager instance; // Singleton
    [Range(0f, 1f)] public float masterVolume;



    private void Awake()
    {   //Singleton
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Preserve the audiomanager while changing scenes
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds) // Atributing the values for the editor
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * masterVolume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    // The first instance of the Audiomanager is in the MainMenu (Where the game will always start) so it plays the intro song
    private void Start()
    {
       Play("IntroTheme");
    }


    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {   
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void StopAll ()
    {
        foreach(Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}
