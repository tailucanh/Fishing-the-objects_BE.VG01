using System;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IMoveToItem
    {
      
        void Init(HookPickUpItem hookPickUpItem);
        void MoveHookToItem(Transform transform);
    }
}
