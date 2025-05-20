using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private int maxSlots = 10;

    private List<Image> slotImages = new List<Image>();

    private void Start()
    {
        // 1) If not set in Inspector, find the Inventory in scene:
        if (inventory == null) inventory = FindObjectOfType<Inventory>();

        // 2) Instantiate empty slots:
        for (int i = 0; i < maxSlots; i++)
        {
            var slotGO = Instantiate(slotPrefab, transform);
            var img = slotGO.GetComponent<Image>();
            img.sprite = null;
            img.enabled = false;
            slotImages.Add(img);
        }

        // 3) Hook up the change event:
        inventory.OnInventoryChanged += RefreshUI;
        // draw initial state:
        RefreshUI();
    }

    private void RefreshUI()
    {
        // clear all first
        for (int i = 0; i < slotImages.Count; i++)
        {
            slotImages[i].sprite = null;
            slotImages[i].enabled = false;
        }

        // fill with current items
        for (int i = 0; i < inventory.Items.Count && i < slotImages.Count; i++)
        {
            slotImages[i].sprite = inventory.Items[i].Icon;
            slotImages[i].enabled = true;
        }
    }
}