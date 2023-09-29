using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : BaseMonoBehaviour
{
    private static AudioBackground instance;
    public static AudioBackground Instance { get => instance; }

    [SerializeField] protected List<AudioSource> audioSources;
    private bool isPauseStart = false;
    private bool isPausePlay = false;
    protected override void Awake()
    {
        base.Awake();
        if (AudioBackground.instance != null) Debug.LogError("Only one AudioBackground object exists");
        AudioBackground.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListSource();
    }

    protected virtual void LoadListSource()
    {
        if (audioSources.Count > 0) return;
        AudioSource[] foundAudioSources = GetComponentsInChildren<AudioSource>(true);
        audioSources.AddRange(foundAudioSources);
    }


    public virtual void PlayAudioBackgroundStart()
    {
        if (audioSources.Count > 0)
        {
            audioSources[0].Play();
            audioSources[1].Stop();
        }
    }

    public virtual void PlayAudioBackgroundPlay()
    {
        if (audioSources.Count > 0)
        {
            audioSources[1].Play();
            audioSources[0].Stop();
        }
    }

    public virtual void AudioBackgroundPause()
    {
        if (audioSources.Count > 0)
        {
            if(audioSources[1].isPlaying)
            {
                audioSources[1].Pause();
                isPausePlay = true;
            }    
              else
            {
                audioSources[0].Pause();
                isPauseStart = true;
            }
              
        }
    }
    public virtual void AudioBackgroundResume()
    {
        if (audioSources.Count > 0)
        {
            if(isPausePlay)
            audioSources[1].UnPause();

            if (isPauseStart)
            audioSources[0].UnPause();
        }
    }


}
