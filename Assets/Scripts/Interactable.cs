using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public enum InteractionType { Dialogue, Inspect, Puzzle }
    public InteractionType type;

    public GameObject speechBubble;
    public float interactionDistance = 2f;

    public string sceneToLoad;
    public bool requiresNote = false;
    public bool noteRead = false;

    private Transform player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (speechBubble != null){
            speechBubble.SetActive(false);

            Button btn = speechBubble.GetComponent<Button>();
            if (btn != null){
                btn.onClick.AddListener(OnSpeechBubbleClicked);
            }
        }
    }

    void Update(){
        float distance = Vector3.Distance(transform.position, player.position);

        if (speechBubble != null){
            speechBubble.SetActive(distance <= interactionDistance);
        }
    }

    public void OnSpeechBubbleClicked(){
        switch (type){
            case InteractionType.Dialogue:
                SceneManager.LoadScene(sceneToLoad);
                break;

            case InteractionType.Inspect:
                Debug.Log("You inspected the object.");
                noteRead = true;
                break;

            case InteractionType.Puzzle:
                if (requiresNote && !noteRead){
                    Debug.Log("You need to read the note first.");
                }
                else{
                    Debug.Log("Puzzle activated"); // open keypad or puzzle of choice here
                }
                break;
        }
    }
}