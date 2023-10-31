using System;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IHookPickup
    {
        event Action DataItemReady;
        Transform Transfrorm { get; set; }

        void PickUpToItem();
      
    }
}
