using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Inventory inventory;      // your singleton/persistent Inventory
    [SerializeField] private GameObject slotPrefab;    // prefab with an Image component
    [SerializeField] private int maxSlots = 5;         // total slot count

    [Header("Which scenes show the bar?")]
    [SerializeField] private string[] scenesToShow;    // e.g. { "Game-MainRoom", "Game-Office" }

    private List<Image> slotImages = new List<Image>();

    private void Awake()
    {
        // Persist this UI across scene loads
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        // If you forgot to wire in the Inspector, grab the singleton
        if (inventory == null)
            inventory = Inventory.Instance;

        // Build your empty slots
        BuildSlots();

        // Listen for changes
        inventory.OnInventoryChanged += RefreshUI;

        // Initial draw based on current scene & current inventory
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Decide whether the bar should be visible in this scene
        bool shouldShow = false;
        foreach (var name in scenesToShow)
        {
            if (scene.name == name)
            {
                shouldShow = true;
                break;
            }
        }

        gameObject.SetActive(shouldShow);

        if (!shouldShow)
            return;

        // Re-parent under the new scene's Canvas (if any)
        var canvas = FindObjectOfType<Canvas>();
        if (canvas != null && transform.parent != canvas.transform)
            transform.SetParent(canvas.transform, worldPositionStays: false);

        // Update the icons
        RefreshUI();
    }

    private void BuildSlots()
    {
        // Clear any existing (in case of reload)
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        slotImages.Clear();

        // Instantiate empty slots
        for (int i = 0; i < maxSlots; i++)
        {
            var slotGO = Instantiate(slotPrefab, transform);
            var img = slotGO.GetComponent<Image>();
            img.enabled = false;     // start invisible
            slotImages.Add(img);
        }
    }

    private void RefreshUI()
    {
        // Clear all
        for (int i = 0; i < slotImages.Count; i++)
        {
            slotImages[i].sprite = null;
            slotImages[i].enabled = false;
        }

        // Fill with current items
        var items = inventory.Items;
        for (int i = 0; i < items.Count && i < slotImages.Count; i++)
        {
            slotImages[i].sprite = items[i].Icon;
            slotImages[i].enabled = true;
        }
    }

    private void OnDestroy()
    {
        if (inventory != null)
            inventory.OnInventoryChanged -= RefreshUI;
    }
}
