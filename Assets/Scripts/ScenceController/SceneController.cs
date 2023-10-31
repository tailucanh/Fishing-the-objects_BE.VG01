using Assets.Scripts.ScenceController.Audios;
using Assets.Scripts.ScenceController.Backgrounds;
using Assets.Scripts.ScenceController.Cameras;
using System;
using UnityEngine;

namespace Assets.Scripts.ScenceController
{
    public enum GameState
    { 
        Start,
        Play,
        End,
        Pause
    }

    public class SceneController : MonoBehaviour
    {

        private GameState _currentState = GameState.Start;
        public event Action<GameState> OnGameStateChangedEvent = delegate { };

        [SerializeField] protected CameraController cameraController;
        [SerializeField] protected BackgroundsController backgroundsController;
        [SerializeField] protected AudiosBackgroundController audiosBackgroundController;

        private void Awake()
        {
            cameraController = GetComponentInChildren<CameraController>();
            backgroundsController = GetComponentInChildren<BackgroundsController>();
            audiosBackgroundController = GetComponentInChildren<AudiosBackgroundController>();
        }


        public GameState CurrentState
        {
            get { return _currentState; }
            set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    OnGameStateChangedEvent?.Invoke(_currentState);
                }
            }
        }

        private void Start()
        {
            Application.targetFrameRate = 60;
            cameraController.Init(this);
            backgroundsController.Init(this);
            audiosBackgroundController.Init(this);

          
        }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
        }

    }
}
