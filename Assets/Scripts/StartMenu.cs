using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("Game-MainRoom");
        SceneManager.LoadScene("Game-OpeningDialogue");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
