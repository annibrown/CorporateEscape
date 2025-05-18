using Unity.VisualScripting;
using UnityEngine;

public class RoomTriggerToOffice : MonoBehaviour
{
    public SwitchRooms SwitchRooms;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SwitchRooms.SwitchRoom("Game-Office");
        }
    }
}
