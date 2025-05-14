using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> Items;
    
    public void Pickup(Item item)
    {
        Items.Add(item);
        item.GetPickedUp();
    }

    public void Drop(Item item, Vector3 playerPosition)
    {
        Items.Remove(item);
        item.GetDropped(playerPosition);
    }
}
