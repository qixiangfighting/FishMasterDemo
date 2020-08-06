using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get { return _instance; }
    }

    private bool isMute = false;

    public void SwitchMuteState()
    {
        isMute = !isMute;

        if (isMute)
        {
            bgmAudioSource.Pause();
        }
        else
        {
            bgmAudioSource.Play();
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public AudioSource bgmAudioSource;

    public AudioClip seaWaveClip;

    public AudioClip goldClip;

    public AudioClip rewardClip;

    public AudioClip fireClip;

    public AudioClip changeClip;

    public AudioClip lvUpClip;


    public void PlayEffectSound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, new Vector3(0,0,-5));
    }

}