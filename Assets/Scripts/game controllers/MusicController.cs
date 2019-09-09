using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    private AudioSource audioSource;

    void Awake()
    {
        MakeSingleton();
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayMusic(bool play)
    {
        if(play)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            
        }

        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            };
        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}