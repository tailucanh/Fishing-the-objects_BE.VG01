using Assets.Scripts.ScenceController.Audios;
using Assets.Scripts.ScenceController.Backgrounds;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ScenceController.Cameras
{
    public class CameraController : MonoBehaviour, IGameStateObserver
    {
        private SceneController _sceneController;
        private ICameraMove _cameraMove;

        private void Awake()
        {
            _cameraMove = GetComponent<ICameraMove>();
        }

        public void Init(SceneController sceneController)
        {
            _sceneController = sceneController;
            _sceneController.OnGameStateChangedEvent += OnGameStateChanged;
            OnGameStateChanged(_sceneController.CurrentState);
        }


        public void OnGameStateChanged(GameState newState)
        {
            switch (newState)
            {
                case GameState.Play:
                    _cameraMove.OnMoveDown();
                    break;
                case GameState.End:
                    _cameraMove.OnMoveUp();
                    break;
            }
        }

      
    }
}