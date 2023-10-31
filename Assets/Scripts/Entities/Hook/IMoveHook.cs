

using UnityEngine;

namespace Assets.Scripts.Entities
{
    internal interface IMoveHook
    {
        bool IsMovingDown { get; }
        bool IsMovingHorizontally { get; set; }
        bool IsMovingUpAfterAttach { get;  set; }
        bool IsMovingToNewPosition { get; }
        bool IsAnimating { get; }
        bool IsDestroyItem { get; set; }
        bool IsCompleteMove { get; }

        void OnMoveHorizontalMiddle(Vector3 targetPosition, IHookAnimation hookAnimation);

        void OnMoveUp(Transform targetObject,  IHookAnimation hookAnimation);

        void OnAttachObjectToHook(Transform targetObject, IHookAnimation hookAnimation);


    }
}
