using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{ 
    public AudioClip bgmClip;

    private AudioSource bgmSource;

    private void Awake()
    {
        bgmSource = GetComponent<AudioSource>();

        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        PlayBGM();
    }

    public void PlayBGM()
    {
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public AudioSource GetBgm()
    {
        return bgmSource;
    }
}
