using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : AudioManager
{

    public Item item;

    private  bool itemClicked = false;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    private Vector3 originalScale;


    protected override void Start()
    {
        base.Start();
        originalScale = transform.localScale;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpriteRenderer();
    }

    protected virtual void LoadSpriteRenderer()
    {
         if (this.spriteRenderer != null) return;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public virtual void Pickup()
    {
        InventoryManager.Instance.RemoveItem(item);
    }

    private void OnDestroy()
    {
        StopAudio();
        Pickup();
        MakeOtherItemsTransparent(1f, true);
    }



    public void OnMouseDown()
    {
        if (!itemClicked)
        {
            HookController.Instance.MoveHook(transform);
            Debug.Log(item.name);
            StartCoroutine(DelayAudioItem());
            itemClicked = true;

            MakeOtherItemsTransparent(0.55f,false);
            Vector3 newScale = originalScale * 1.2f; 
            transform.localScale = newScale;

            StartCoroutine(ReturnToOriginalSize());
        }
       
    }

    private IEnumerator DelayAudioItem()
    {
        yield return new WaitForSeconds(5.7f);

        PlayOneShot(item.audio);
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
