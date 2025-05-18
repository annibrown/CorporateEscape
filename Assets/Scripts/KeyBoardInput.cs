using UnityEngine;

public class KeyBoardInput : MonoBehaviour
{
    public OfficeWorker OfficeWorker;
    public Player Player;
    
    // Update is called once per frame
    public void Update()
    {

        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        if (OfficeWorker == null)
        {
            OfficeWorker = GameObject.FindGameObjectWithTag("Player").GetComponent<OfficeWorker>();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.PickupNearbyItems();
        }
        
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            // move up
            OfficeWorker.MoveManually(new Vector2(0, 1));
        }
        if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            // move down
            OfficeWorker.MoveManually(new Vector2(0, -1));
        }
        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            // move left
            OfficeWorker.MoveManually(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            // right
            OfficeWorker.MoveManually(new Vector2(1, 0));
        }
        
    }
}