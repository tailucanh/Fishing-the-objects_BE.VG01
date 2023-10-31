
using UnityEngine;

namespace Assets.Scripts.ScenceController.Backgrounds
{
    public abstract class BaseBackground : MonoBehaviour
    {
        public abstract void HandleStateChange(GameState newState);
        public void ShowBackground() {
            gameObject.SetActive(true);
        }
        public  void HideBackground(){
            gameObject.SetActive(false);

        }
    }
}
