using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchRooms : MonoBehaviour
{
    public void SwitchRoom(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
