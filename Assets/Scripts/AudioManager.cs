using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Variablendefinition
    public Sound[] sounds;

    public static AudioManager instance;

    //Wird für die Initialisierung verwendet
    void Awake()
    {
        //jeder Sound bekommt eine AudioSource zugewiesen
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
     
        }
    }

    void Start()
    {
        //Das Theme wird beim Start abgespielt
        Play("Theme");
    }

    //Methode zum abspielen von Sounds
    public void Play(string name)
    {
        //Die Liste wird nach einem Sound durchsucht die zu dem mitgegebenem Namen passt
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        //Fehlermeldung falls der Sound nicht in der Liste gefunden wird
        if(s == null)
        {
            Debug.LogWarning("Der Sound mit dem Namen "+name+" wurde nicht in der Liste gefunden");
            return;
        }
   
        //Ton wird abgespielt
        s.source.Play();
    }

    //Methode zum abspielen von Sounds
    public void Stop(string name)
    {
        //Die Liste wird nach einem Sound durchsucht die zu dem mitgegebenem Namen passt
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //Fehlermeldung falls der Sound nicht in der Liste gefunden wird
        if (s == null)
        {
            Debug.LogWarning("Der Sound mit dem Namen " + name + " wurde nicht in der Liste gefunden");
            return;
        }

        //Ton wird abgespielt
        s.source.Stop();
    }
}
