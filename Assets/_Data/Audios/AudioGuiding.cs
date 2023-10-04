using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGuiding : AudioManager
{

    private static AudioGuiding instance;
    public static AudioGuiding Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (AudioGuiding.instance != null) return;
        AudioGuiding.instance = this;
    }

  
    public virtual void GuidingAudioPlay()
    {
        PlayAudio();
    }

    public virtual void GuidingAudioStop()
    {
        StopAudio();
    }

    public virtual void GuidingAudioPasue()
    {
        PauseAudio();
    }

    public virtual void GuidingAudioResume()
    {
        ResumeAudio();
    }
}
