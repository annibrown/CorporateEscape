using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Event fired whenever the inventory changes
    public event Action OnInventoryChanged;
    public static Inventory Instance { get; private set; }

    private List<Item> items = new List<Item>();
    public IReadOnlyList<Item> Items => items;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);              // only one allowed
            return;
        }
        Instance = this;
    }

    public void Pickup(Item item)
    {
        // items.Add(item);
        // item.GetPickedUp();
        // OnInventoryChanged?.Invoke();
        
        if (!items.Contains(item))
        {
            items.Add(item);
            OnInventoryChanged?.Invoke();
        }
    }

    public void Drop(Item item, Vector3 playerPosition)
    {
        if (items.Remove(item))
        {
            item.GetDropped(playerPosition);
            OnInventoryChanged?.Invoke();
        }
    }

    public bool InInventory(Item item) => items.Contains(item);
}