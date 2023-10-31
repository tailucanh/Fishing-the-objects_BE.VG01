using Assets.Scripts.Audios;
using Assets.Scripts.UI;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class ItemPickup : MonoBehaviour, IHookPickup
    {

        [SerializeField] protected Item item;

        [SerializeField] protected SpriteRenderer spriteRenderer;
        private Vector3 originalScale;
        private bool _isItemClicked = false;

        public event Action DataItemReady;

        public Transform Transfrorm { get; set; } 


        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
          
        }
        protected void Start()
        {
            item.transformItem = transform;
            originalScale = transform.localScale;
        }

        private void OnDestroy()
        {
            ItemsManager.Instance.AddItem(item);
            MakeOtherItemsTransparent(1f, true);
        }

        public void OnMouseDown()
        {
            GetName();
            PickUpToItem();
        }
        public void PickUpToItem()
        {
            if (!_isItemClicked)
            {

                _isItemClicked = true;
                MakeOtherItemsTransparent(0.55f, false);
                ScaleClick();
                ItemTextUI.Instance.OnShowItem(item.itemName, item.audio);

                Transfrorm = item.transformItem;
                DataItemReady?.Invoke();
            }
    

        }
        public string GetName()
        {
            return item.itemName;
        }
        protected virtual void ScaleClick()
        {
            Vector3 newScale = originalScale * 1.2f;
            transform.localScale = newScale;
            StartCoroutine(ReturnToOriginalSize());
        }

        private IEnumerator ReturnToOriginalSize()
        {
            yield return new WaitForSeconds(0.3f);

            transform.localScale = originalScale;
        }
        private void MakeOtherItemsTransparent(float transparent, bool onClick)
        {
            ItemPickup[] allItems = FindObjectsOfType<ItemPickup>();
            foreach (ItemPickup otherItem in allItems)
            {
                if (otherItem != this)
                {
                    Color newColor = otherItem.spriteRenderer.color;
                    newColor.a = transparent;
                    otherItem.spriteRenderer.color = newColor;

                    otherItem.GetComponent<BoxCollider2D>().enabled = onClick;


                }
            }
        }

        
    }
}