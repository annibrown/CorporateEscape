using UnityEngine;
using UnityEngine.UI;


public class MiniGameCoffeeMachine : MonoBehaviour
{
    public Text TimerText;
    public GameTimer GameTimer;
    public SwitchRooms SwitchRooms;
    //public Item coffeeItem;
    public CanvasGroup PopupCanvasGroup;
    public CoffeeDropPlacer CoffeeDropPlacer;
    public Text WinResultText;
    public Text ScoreText;
    public Sprite CoffeeSprite;
    
    private bool hasWon = false;

    private int secondsToPlay = 25;
    private SpriteRenderer playerSpriteRenderer;
    private CanvasGroup inventoryCanvasGroup;
    
    void Start()
    {
        if (SwitchRooms == null)
        {
            SwitchRooms = FindObjectOfType<SwitchRooms>();
        }
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        playerSpriteRenderer.enabled = false;
        
        GameObject inventoryBarObject = GameObject.FindGameObjectWithTag("InventoryBar");
        inventoryCanvasGroup = inventoryBarObject.GetComponent<CanvasGroup>();
        CanvasGroupDisplayer.Hide(inventoryCanvasGroup);
        
        CanvasGroupDisplayer.Hide(PopupCanvasGroup);
        GameTimer.StartTimer(secondsToPlay, OnTimerEnded); 
    }

    void Update()
    {
        if (GameTimer.IsTimerRunning())
        {
            TimerText.text = GameTimer.GetTimeAsString();
        }
    }

    public void onStartButtonClicked()
    {
        GameTimer.StartTimer(secondsToPlay, OnTimerEnded); 
    }
    
    public void OnTimerEnded()
    {
        print ("Game Over");
        Cursor.visible = true;
        //Inventory.Instance.Pickup(coffeeItem);
        CoffeeDropPlacer.Stop();
        ShowEndGamePopup();
    }

    public void ShowEndGamePopup()
    {
        if (ScoreKeeper.GetScore() >= 20)
        {
            hasWon = true;
            WinResultText.text = "You win!";
        }
        else
        {
            hasWon = false;
            WinResultText.text = "Try again!";
        }
        CanvasGroupDisplayer.Show(PopupCanvasGroup);
    }

    public void OnPopupClosed()
    {
        CanvasGroupDisplayer.Hide(PopupCanvasGroup);
        if (hasWon)
        {
            Win();
        }
        else
        {
            StartOver();
        }
    }

    private void StartOver()
    {
        GameTimer.StartTimer(secondsToPlay, OnTimerEnded); 
        ScoreKeeper.Reset();
        ScoreText.text = "Score: 0";
        CoffeeDropPlacer.Restart();
    }

    public void Win()
    {
        Item coffeeItem = new Item();
        coffeeItem.Name = "Coffee";
        coffeeItem.Icon = CoffeeSprite;
        if (InventoryNew.Instance != null)
            InventoryNew.Instance.PickUpItem(coffeeItem);
        
        playerSpriteRenderer.enabled = true;
        CanvasGroupDisplayer.Show(inventoryCanvasGroup);
        SwitchRooms.SwitchRoom("Game-BreakRoom");
    }
    
    
}