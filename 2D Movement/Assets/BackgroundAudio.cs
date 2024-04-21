using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundAudio : MonoBehaviour
{
    public AudioClip backgroundMusic; // 15 nebuvo priskirtas
    AudioSource audioSource;
    
    private void Start()
    {
        audioSource  = gameObject.GetComponent<AudioSource>(); // 4 priskyrimas neturetu buti update, nes mes tai darome tik viena karta
        GetComponent<AudioSource>().clip = backgroundMusic;
        GetComponent<AudioSource>().Play();
    }
}

// Added Camera