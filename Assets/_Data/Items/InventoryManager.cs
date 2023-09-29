using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : BaseMonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance { get => instance; }
    public List<Item> listItems = new List<Item>();

    protected override void Awake()
    {
        base.Awake();
        if (InventoryManager.instance != null) Debug.LogError("Only one InventoryManager object exists");
        InventoryManager.instance = this;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItems();
    }

    protected virtual void LoadItems()
    {
        if (listItems.Count > 0) return;
        ItemPickup[] itemPickups = GetComponentsInChildren<ItemPickup>();

        foreach (ItemPickup itemPickup in itemPickups)
        {
            if (itemPickup != null)
            {
                Item item = itemPickup.item;
                listItems.Add(item);
            }
        }
    }

    protected override void Update()
    {
        base.Update();
       
    }


    public virtual int ListSize()
    {
        return listItems.Count;
    }


    public virtual void RemoveItem(Item item)
    {
        listItems.Remove(item);
    }



}
