using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Player Player;
    
    // Update is called once per frame - test
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.PickupNearbyItems();
        }
    }
}
