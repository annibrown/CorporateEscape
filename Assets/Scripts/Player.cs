using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour
{
    public SpriteRenderer PlayerSpriteRenderer;

    private Inventory inventory;

    private float pickupDistance = 1.0f;

    public GameObject coffee;
    public GameObject coffeeMachinePiece;
    private Item coffeeMachinePieceItem;

    public void Start()
    {
        inventory = new Inventory();
        GameObject coffeeCup = Instantiate(coffee, transform.position, Quaternion.identity);
        
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
    
    // On Click coffee machine part
    public void OnClickCoffeeMachinePart()
    {
        GameObject pieceObj = Instantiate(coffeeMachinePiece, transform.position, Quaternion.identity);
        coffeeMachinePieceItem = pieceObj.GetComponent<Item>();
        inventory.Pickup(coffeeMachinePieceItem);
    }
    
    private void OnClickCoffeeMachine()
    {
        if (inventory.InInventory(coffeeMachinePieceItem))
        {
            // display "yay! you fixed the machine!"
            GameObject coffeeObj = Instantiate(coffee, transform.position, Quaternion.identity);
            Item coffeeItem = coffeeObj.GetComponent<Item>();
            inventory.Pickup(coffeeItem);
            // "coffee added to your inventory!"
        }
        else
        {
            //display "hmm.. the coffee machine seems to be broken.."
        }
    }
    
}
