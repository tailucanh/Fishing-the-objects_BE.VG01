using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseMonoBehaviour
{
    private bool isPaused = false;

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        isPaused = true;
        AudioBackground.Instance.AudioBackgroundPause();
        AudioCongrats.Instance.CongratsAudioPasue();
        AudioHook.Instance.HookAudioPasue();
        AudioHurrah.Instance.HurrahAudioPasue();
        AudioPickup.Instance.PickUpAudioPasue();
        AudioGuiding.Instance.GuidingAudioPasue();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
        AudioBackground.Instance.AudioBackgroundResume();
        AudioCongrats.Instance.CongratsAudioResume();
        AudioHook.Instance.HookAudioResume();
        AudioHurrah.Instance.HurrahAudioResume();
        AudioPickup.Instance.PickUpAudioResume();
        AudioGuiding.Instance.GuidingAudioResume();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    
    public void QuitGame()
    {
        Application.Quit();
    
    }


    // Hàm cập nhật game logic
    protected override void Update()
    {
        if (!isPaused)
        {
            
        }
    }
}
