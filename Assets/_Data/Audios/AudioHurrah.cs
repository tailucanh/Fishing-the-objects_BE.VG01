using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHurrah : AudioManager
{
    private static AudioHurrah instance;
    public static AudioHurrah Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (AudioHurrah.instance != null) return;
        AudioHurrah.instance = this;
    }

    public virtual void HurrahAudioPlay()
    {
        PlayAudio();
        audioSource.loop = true;
    }

    public virtual void HurrahAudioStop()
    {
        StopAudio();
    }


    public virtual void HurrahAudioPasue()
    {
        PauseAudio();
    }

    public virtual void HurrahAudioResume()
    {
        ResumeAudio();
    }
}
