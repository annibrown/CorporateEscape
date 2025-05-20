using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MartyDialogue : MonoBehaviour
{
    public GameObject mcBubble;
    public Text mcText;
    
    public GameObject MartyBubble;
    public Text MartyText;
    public GameObject MartySprite;

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
            MartySprite.SetActive(false);
        }
        
        bool mcTurn = (currentLine % 2 == 0);

        if (mcTurn)
        {
            mcBubble.SetActive(true);
            MartyBubble.SetActive(false);
            mcText.text = lines[currentLine];
        }
        else
        {
            mcBubble.SetActive(false);
            MartyBubble.SetActive(true);
            MartyText.text = lines[currentLine];
        }
    }
}