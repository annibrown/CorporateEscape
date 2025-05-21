using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryNew : MonoBehaviour
{
    public InventoryUINew InventoryUINew;
    private List<Item> items = new List<Item>();
    public static InventoryNew Instance { get; private set; }
    
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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpItem(Item item)
    {
        items.Add(item);
        InventoryUINew.AddItemToSlot(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        InventoryUINew.RemoveItemFromSlot(item);
    }
}
