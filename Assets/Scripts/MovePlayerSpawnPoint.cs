using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayerSpawnPoint : MonoBehaviour
{
    
    private Vector3 breakRoomPoint = new Vector3(-7f,-2f,0);
    private Vector3 officeRoomPoint = new Vector3(-7f,-2f,0);
    private Vector3 mainRoomPoint = new Vector3(8f,-2f,0);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player == null)
            print("Couldn't find player!");
        
        if (SceneManager.GetActiveScene().name == "Game-BreakRoom")
        {
            player.transform.position = breakRoomPoint;
        }
        if (SceneManager.GetActiveScene().name == "Game-Office")
        {
            player.transform.position = officeRoomPoint;
        }
        if (SceneManager.GetActiveScene().name == "Game-MainRoom")
        {
            player.transform.position = mainRoomPoint;
        }
    }
    
}
