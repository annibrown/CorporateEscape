using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningDialogue : MonoBehaviour
{
    public GameObject mcBubble;
    public Text mcText;
    
    public GameObject chadBubble;
    public Text chadText;
    public GameObject chadSprite;

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
        if (currentLine == lines.Length - 1)
        {
            chadSprite.SetActive(false);
        }
        
        bool mcTurn = (currentLine % 2 == 0);

        if (mcTurn)
        {
            mcBubble.SetActive(true);
            chadBubble.SetActive(false);
            mcText.text = lines[currentLine];
        }
        else
        {
            mcBubble.SetActive(false);
            chadBubble.SetActive(true);
            chadText.text = lines[currentLine];
        }
    }
}
