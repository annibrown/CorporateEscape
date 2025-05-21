using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MartyDialogue : MonoBehaviour
{
    public GameObject mcBubble;
    public Text mcText;
    
    public GameObject martyBubble;
    public Text martyText;

    public string[] lines;

    private int currentLine = 0;

    void Start()
    {
        ShowLine();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine++;
            if (currentLine >= lines.Length)
            {
                SceneManager.LoadScene("Game-MainRoom");
                return;
            }
            ShowLine();
        }
    }

    void ShowLine()
    {
        bool martyTurn = (currentLine % 2 == 0);

        if (martyTurn)
        {
            mcBubble.SetActive(false);
            martyBubble.SetActive(true);
            mcText.text = lines[currentLine];
        }
        else
        {
            mcBubble.SetActive(true);
            martyBubble.SetActive(false);
            martyText.text = lines[currentLine];
        }
    }
}