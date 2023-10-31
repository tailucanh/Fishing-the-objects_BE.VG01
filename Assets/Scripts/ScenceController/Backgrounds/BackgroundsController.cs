using UnityEngine;

namespace Assets.Scripts.ScenceController.Backgrounds
{
    public class BackgroundsController : MonoBehaviour, IGameStateObserver
    {
        private SceneController _sceneController;

        [SerializeField] protected BackgroundStart backgroundStart;
        [SerializeField] protected BackgroundEnd backgroundEnd;
        [SerializeField] protected BackgroundPlay backgroundPlay;


        public void Init(SceneController sceneController)
        {
            _sceneController = sceneController;
            _sceneController.OnGameStateChangedEvent += OnGameStateChanged;
            OnGameStateChanged(_sceneController.CurrentState);
        }

        private void Awake()
        {
            backgroundStart = GetComponentInChildren<BackgroundStart>();
            backgroundEnd = GetComponentInChildren<BackgroundEnd>();
            backgroundPlay = GetComponentInChildren<BackgroundPlay>();

        }
      

        public void OnGameStateChanged(GameState newState)
        {
            if(backgroundStart != null)
                backgroundStart.HandleStateChange(newState);
            if (backgroundEnd != null)
                backgroundEnd.HandleStateChange(newState);
            if (backgroundEnd != null)
                backgroundPlay.HandleStateChange(newState);
        }

    }
}
