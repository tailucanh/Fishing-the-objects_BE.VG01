using Assets.Scripts.Audios;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class GameUIManager : MonoBehaviour
    {
        private bool isPaused = false;

        public void PauseGame()
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            isPaused = true;

        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            isPaused = false;
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

        protected void Update()
        {
            if (!isPaused)
            {

            }
        }
    }
}