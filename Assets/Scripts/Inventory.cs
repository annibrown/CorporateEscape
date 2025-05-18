using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Event fired whenever the inventory changes
    public event Action OnInventoryChanged;

    private List<Item> items = new List<Item>();
    public IReadOnlyList<Item> Items => items;

    private void Awake()
    {
        // nothing else needed here yet
    }

    public void Pickup(Item item)
    {
        items.Add(item);
        item.GetPickedUp();
        OnInventoryChanged?.Invoke();
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