using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game-MainRoom");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
