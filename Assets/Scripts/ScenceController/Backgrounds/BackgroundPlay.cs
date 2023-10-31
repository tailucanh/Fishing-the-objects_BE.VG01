using Assets.Scripts.Entities;
using System;
using Unity.VisualScripting;

namespace Assets.Scripts.ScenceController.Backgrounds
{
    public class BackgroundPlay : BaseBackground
    {
        private IHookObject _hookObject;
        public event Action OnPlayStateChanged = delegate { };
        public event Action OnEndWithPlayStatdeChanged = delegate { };

        private void Awake()
        {
            _hookObject = transform.Find("Player").gameObject.GetComponentInChildren<IHookObject>();
        }

        public override void HandleStateChange(GameState newState)
        {
            switch (newState)
            {
                case GameState.Play:
                    OnPlayStateChanged?.Invoke();
                    break;
                case GameState.End:
                    OnEndWithPlayStatdeChanged?.Invoke();
                    _hookObject.Hide();
                    break;
                default:
                    break;
            }

        }

    }
}
