using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUINew : MonoBehaviour
{
    public List<Image> Slots;

    private int freeSlotIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToSlot(Item item)
    {
        Slots[freeSlotIndex].sprite = item.Icon;
        freeSlotIndex = freeSlotIndex + 1;
    }

    public void RemoveItemFromSlot(Item item)
    {
        foreach (Image image in Slots)
        {
            if (image.sprite == item.Icon)
                image.sprite = null;
        }
    }
}
