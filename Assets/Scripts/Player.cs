using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour
{
    public SpriteRenderer PlayerSpriteRenderer;

    private Inventory inventory;

    private float pickupDistance = 1.0f;

    public void Start()
    {
        inventory = new Inventory();
    }
    
    public void Update()
    {
        
    }

    public void PickupNearbyItems()
    {
        List<GameObject> itemObjects = GameObject.FindGameObjectsWithTag("Item").ToList();
        
        List<Item> nearbyItems = new List<Item>();
        foreach (GameObject itemObject in itemObjects)
        {
            Item item = itemObject.GetComponent<Item>();
            nearbyItems.Add(item);
        }
        
        foreach (Item item in nearbyItems)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);
            if (distance <= pickupDistance)
            {
                inventory.Pickup(item);
            }
        }
    }

    public void DropItem(Item item)
    {
        inventory.Drop(item, gameObject.transform.position);
    }
    
    // On Click Coffee Machine
    /*private void CoffeeMachine()
    {
        if (Inventory.InInventory(coffeeMachine)
        {
            // display "yay! you fixed the machine!"
            // "coffee added to your inventory!"
            Inventory.Pickup(coffee);
        }
        
    }*/

    
    
}
