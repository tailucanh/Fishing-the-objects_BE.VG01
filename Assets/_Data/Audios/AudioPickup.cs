using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPickup : AudioManager
{
    private static AudioPickup instance;
    public static AudioPickup Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (AudioPickup.instance != null) return;
        AudioPickup.instance = this;
    }

    public virtual void PickUpAudio()
    {
        PlayAudio();
    }


    public virtual void PickUpAudioPasue()
    {
        PauseAudio();
    }

    public virtual void PickUpAudioResume()
    {
        ResumeAudio();
    }

}
