using UnityEngine;

public class KeyBoardInput : MonoBehaviour
{
    public OfficeWorker OfficeWorker;
    public Player Player;
    
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.PickupNearbyItems();
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            // move up
            OfficeWorker.MoveManually(new Vector2(0, 1));
        }
        if (Input.GetKey(KeyCode.S))
        {
            // move down
            OfficeWorker.MoveManually(new Vector2(0, -1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            // move left
            OfficeWorker.MoveManually(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            // right
            OfficeWorker.MoveManually(new Vector2(1, 0));
        }
        
    }
}