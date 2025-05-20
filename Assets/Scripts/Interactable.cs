using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactionPrompt;

    // This method will be called when the player interacts with this object
    public abstract void OnInteract();
}
