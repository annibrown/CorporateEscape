using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text ScoreText;
    public Text TimeText;
    public GameTimer GameTimer;

    public void Update()
    {
        ShowTime();
    }
    public void ShowScore()
    {
        ScoreText.text = "Score: " + ScoreKeeper.GetScore();
    }

    public void ShowTime()
    {
        TimeText.text = GameTimer.GetTimeAsString();
    }
}
