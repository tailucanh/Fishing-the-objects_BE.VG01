using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCongrats : AudioManager
{
    private static AudioCongrats instance;
    public static AudioCongrats Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (AudioCongrats.instance != null) return;
        AudioCongrats.instance = this;
    }

    public virtual void CongratsAudioPlay()
    {
        PlayAudio();
        audioSource.loop = true;
    }

    public virtual void CongratsAudioStop()
    {
        StopAudio();
    }

    public virtual void CongratsAudioPasue()
    {
        PauseAudio();
    }

    public virtual void CongratsAudioResume()
    {
        ResumeAudio();
    }




}
