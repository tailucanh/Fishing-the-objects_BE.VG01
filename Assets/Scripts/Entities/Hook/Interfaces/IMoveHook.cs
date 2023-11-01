
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public  interface IMoveHook
    {
        bool IsMoving { get; set; }

        void OnMoveHook(Transform targetObject, IHookAnimation hookAnimation);
    }
}
