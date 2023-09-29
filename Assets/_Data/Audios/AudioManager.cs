using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public abstract class AudioManager : BaseMonoBehaviour
{
    [Header("Audio Manager")]
    [SerializeField] protected AudioSource audioSource;

   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
    }

    protected virtual void LoadAudioSource()
    {
        if (this.audioSource != null) return;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audioSource.Play();
   
    }
    public void PlayOneShot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayLoop(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
        audioSource.loop = true;
    }
  

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void PauseAudio()
    {
        audioSource.Pause();
    }
    public void ResumeAudio()
    {
        audioSource.UnPause();
    }

}
