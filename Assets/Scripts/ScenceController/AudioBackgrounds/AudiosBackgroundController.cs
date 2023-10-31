using Assets.Scripts.ScenceController.Backgrounds;
using UnityEngine;

namespace Assets.Scripts.ScenceController.Audios
{
    public class AudiosBackgroundController : MonoBehaviour, IGameStateObserver
    {
        private SceneController _sceneController;

        [SerializeField] protected AudioStartBackground audioStartBackground;
        [SerializeField] protected AudioPlayBackground audioPlayBackground;
        [SerializeField] protected AudioEndBackground audioEndBackground;

        public void Init(SceneController sceneController)
        {
            _sceneController = sceneController;
            _sceneController.OnGameStateChangedEvent += OnGameStateChanged;
            OnGameStateChanged(_sceneController.CurrentState);
        }

        private void Start()
        {
            audioStartBackground = GetComponentInChildren<AudioStartBackground>();
            audioPlayBackground = GetComponentInChildren<AudioPlayBackground>();
            audioEndBackground = GetComponentInChildren<AudioEndBackground>();

        }



        public void OnGameStateChanged(GameState newState)
        {
            if(audioStartBackground != null)
                audioStartBackground.HandleStateChange(newState);
            if (audioPlayBackground != null)
                audioPlayBackground.HandleStateChange(newState);
            if (audioEndBackground != null)
                audioEndBackground.HandleStateChange(newState);
          
        }

      

    }

}
