using UnityEngine;

public class Cheaty : MonoBehaviour
{

    public Sprite CoffeeSprite;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Item coffeeItem = new Item();
            coffeeItem.Name = "Coffee";
            coffeeItem.Icon = CoffeeSprite;
            InventoryNew.Instance.PickUpItem(coffeeItem);
        }
    }
}
