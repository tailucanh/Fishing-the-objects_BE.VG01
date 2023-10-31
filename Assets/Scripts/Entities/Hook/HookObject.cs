
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class HookObject : MonoBehaviour, IHookObject
    {
      
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
