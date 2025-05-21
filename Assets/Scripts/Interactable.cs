using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public enum InteractionType { Dialogue, Inspect, Puzzle }
    public InteractionType type;

    public GameObject speechBubble;
    public float interactionDistance = 3.5f;

    public string firstDialogueScene;
    public string secondDialogueScene;
    public string thirdDialogueScene;
    
    public CanvasGroup firstDialogueCanvasGroup;

    public Item requiredItem;

    private Transform player;
    private Inventory inventory;
    private MartyDialogueState martyState;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = player.GetComponent<Inventory>();
        
        if (speechBubble != null){
            speechBubble.SetActive(false);
            Button btn = speechBubble.GetComponent<Button>();
            if (btn != null){
                btn.onClick.AddListener(OnSpeechBubbleClicked);
            }
        }
        martyState = GetComponent<MartyDialogueState>();
    }

    void Update()
    {
        if (player == null) return;
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (speechBubble != null){
            speechBubble.SetActive(distance <= interactionDistance);
        }
    }

    // public void OnSpeechBubbleClicked(){
    //     switch (type){
    //         case InteractionType.Dialogue:
    //             SceneManager.LoadScene(sceneToLoad);
    //             break;
    //
    //         case InteractionType.Inspect:
    //             Debug.Log("You inspected the object.");
    //             noteRead = true;
    //             break;
    //
    //         case InteractionType.Puzzle:
    //             if (requiresNote && !noteRead){
    //                 Debug.Log("You need to read the note first.");
    //             }
    //             else{
    //                 Debug.Log("Puzzle activated"); // open keypad or puzzle of choice here
    //             }
    //             break;
    //     }
    // }

    void OnSpeechBubbleClicked()
    {
        print("OnSpeechBubbleClicked");
        if (martyState != null)
        {
            if (!MartyDialogueState.hasDoneFirstDialogue)
            {
                MartyDialogueState.hasDoneFirstDialogue = true;
                
                // show the dialogue canvas 
                //CanvasGroupDisplayer.Show(firstDialogueCanvasGroup);
                SceneManager.LoadScene(firstDialogueScene);
            }
            else
            {
                if (!inventory.InInventory(requiredItem))
                {
                    Debug.Log("Marty: Where's my coffee");
                }
                else
                {
                    SceneManager.LoadScene(secondDialogueScene);
                }
            }
        }
        else
        {
            if (type == InteractionType.Dialogue)
            {
                SceneManager.LoadScene(firstDialogueScene);
            }
        }
    }
}