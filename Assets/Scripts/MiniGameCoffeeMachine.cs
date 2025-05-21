using UnityEngine;


public class MiniGameCoffeeMachine : MonoBehaviour
{
    public GameTimer GameTimer;
    public SwitchRooms SwitchRooms;
    public Item coffeeItem;
    
    void Start()
    {
        if (SwitchRooms == null)
        {
            SwitchRooms = FindObjectOfType<SwitchRooms>();
        }
    }

    public void onStartButtonClicked()
    {
        GameTimer.StartTimer(5, OnTimerEnded); 
    }
    
    public void OnTimerEnded()
    {
        print ("Game Over");
        //Inventory.Instance.Pickup(coffeeItem);
        Win();
    }

    public void Win()
    {
        InventoryNew.Instance.PickUpItem(coffeeItem);
        SwitchRooms.SwitchRoom("Game-BreakRoom");
    }
    
    
}