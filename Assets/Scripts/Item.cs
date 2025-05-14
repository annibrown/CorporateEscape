using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name = "Unknown";
    public Sprite Icon;

    private CanvasGroup canvasGroup;
    
    public void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPickedUp()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        gameObject.tag = "ItemPickedUp";
    }

    public void GetDropped(Vector3 playerPosition)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        
        gameObject.tag = "Item";
        
        gameObject.transform.position = playerPosition;
    }
}
