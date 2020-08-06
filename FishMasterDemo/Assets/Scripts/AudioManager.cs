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

    public bool IsMure
    {
        get
        {
            return isMute;
        }
    }

    private bool isMute = false;

    public void SwitchMuteState(bool isOn)
    {
        isMute = !isOn;

        DoMute();

    }

    private void DoMute()
    {
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
        isMute = PlayerPrefs.GetInt("mute", 0) != 0;

        DoMute();
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