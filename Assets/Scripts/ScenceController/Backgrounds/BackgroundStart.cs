using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts.ScenceController.Backgrounds
{
    public class BackgroundStart : BaseBackground
    {
        private ICloudGenerate _cloudGenerate;

        private void Awake()
        {
            _cloudGenerate = GetComponentInChildren<ICloudGenerate>();
        }

        private void Update()
        {
            if (Time.time >= 4f)
            {
                _cloudGenerate.StopGenerate();
            }
        }

        public override void HandleStateChange(GameState newState)
        {
            switch (newState)
            {
                case GameState.Start:
                    _cloudGenerate.StartGenerate();
                    ShowBackground();
                    break;
                case GameState.End:
                    HideBackground();
                    break;
            }
        }

    }
}
