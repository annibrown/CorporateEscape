using UnityEngine;


public class MiniGameCoffeeMachine : MonoBehaviour
{
    public GameTimer GameTimer;
    public SwitchRooms SwitchRooms;
    
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
        SwitchRooms.SwitchRoom("Game-BreakRoom");

    }
    
    
}