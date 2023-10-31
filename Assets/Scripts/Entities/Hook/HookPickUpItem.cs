using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class HookPickUpItem : MonoBehaviour
    {
        private List<IHookPickup> _hookPickupItems = new List<IHookPickup>();
        public event Action<Transform> OnChangeTransformItem = delegate { };
        private IMoveToItem _moveToItem;

        private void Awake()
        {
            _moveToItem = GetComponent<IMoveToItem>();
            IHookPickup[] items = GameObject.Find("Items").GetComponentsInChildren<IHookPickup>();
            _hookPickupItems.AddRange(items);

            foreach (var item in _hookPickupItems)
            {
                if (item != null)
                {
                    item.DataItemReady += HandleDataReady;
                }
            }
        }
        private void Start()
        {
            _moveToItem.Init(this);
        }

        private void HandleDataReady()
        {
            foreach (var item in _hookPickupItems)
            {
                if (item != null)
                {
                    OnChangeTransformItem?.Invoke(item.Transfrorm);
                }
                else
                {
                    Debug.Log("Chưa Click item");
                }
            }
           

        }

    }
}
