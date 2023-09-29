using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHook : AudioManager
{

    private static AudioHook instance;
    public static AudioHook Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (AudioHook.instance != null) return;
        AudioHook.instance = this;
    }

    public virtual void HookAudioPlay()
    {
        PlayAudio();
    }

    public virtual void HookAudioStop()
    {
        StopAudio();
    }

    public virtual void HookAudioPasue()
    {
        PauseAudio();
    }

    public virtual void HookAudioResume()
    {
        ResumeAudio();
    }



}
