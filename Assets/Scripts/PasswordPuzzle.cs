using UnityEngine;
using UnityEngine.UI;

public class PasswordPuzzle : MonoBehaviour
{
    [Header("UI References")]
    public InputField passwordInput;
    public Button submitButton;
    public Text feedbackText;

    [Header("Puzzle Settings")]
    public string correctPassword = "coffee123";  // change this to whatever you like
    public bool puzzleSolved = false;

    private void Start()
    {
        // Set initial message
        // feedbackText.text = "Enter the password.";
        submitButton.onClick.AddListener(CheckPassword);
    }

    void CheckPassword()
    {
        string enteredPassword = passwordInput.text;

        if (enteredPassword == correctPassword)
        {
            feedbackText.text = "Access granted!";
            puzzleSolved = true;
            submitButton.interactable = false;
            passwordInput.interactable = false;

            // Notify PuzzleManager or GameManager here if needed
            // e.g., PuzzleManager.Instance.MarkPuzzleSolved("ComputerLogin");
        }
        else
        {
            feedbackText.text = "Incorrect password. Try again.";
            passwordInput.text = "";  // Clear input field
        }
    }
}

