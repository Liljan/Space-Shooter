﻿using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AUDIO_SETTINGS.MASTER_VOLUME = 1f;
        AUDIO_SETTINGS.SFX_VOLUME = 1f;
        AUDIO_SETTINGS.MUSIC_VOLUME = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySFX(AudioClip ac)
    {
        audioSource.PlayOneShot(ac,AUDIO_SETTINGS.MASTER_VOLUME*AUDIO_SETTINGS.SFX_VOLUME);
    }

    public void PlaySFXRandomPitch(AudioClip ac)
    {
        audioSource.pitch = Random.Range(0.5f, 2.1f);
        audioSource.PlayOneShot(ac, AUDIO_SETTINGS.MASTER_VOLUME * AUDIO_SETTINGS.SFX_VOLUME);
        //audioSource.pitch = 1f;
    }

    public void LoopMusic(AudioClip ms)
    {
        // TODO
    }
}
