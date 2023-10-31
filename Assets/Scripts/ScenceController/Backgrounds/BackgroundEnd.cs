using Assets.Scripts.Entities;

namespace Assets.Scripts.ScenceController.Backgrounds
{
    public class BackgroundEnd : BaseBackground
    {
        private ICloudGenerate _cloudGenerate;

        private void Awake()
        {
            _cloudGenerate = GetComponentInChildren<ICloudGenerate>();
        }

 
        public override void HandleStateChange(GameState newState)
        {
            switch (newState)
            {
                case GameState.Start:
                    HideBackground();
                    break;
                case GameState.End:
                    ShowBackground();
                    _cloudGenerate.StartGenerate();
                    break;
            }
        }

    }
}
