using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum TextEnum
{
    Healt, Timer, Case
}

public class UiManager : MonoBehaviour
{
    // References to UI Text components for health, timer, and case messages.
    private Text healtText;
    private Text timerText;
    private Text caseText;

    // Reference to the retry button.
    private Button retryButton;

    private void Awake()
    {
        // Assign references to the UI components.
        FindAndAssignComponents();
    }

    private void Start()
    {
        // Add the retry button click event listener.
        retryButton.onClick.AddListener(StartAgain);
    }

    // Finds and assigns the UI components (Text and Button) from the scene hierarchy.
    private void FindAndAssignComponents()
    {
        healtText = transform.Find("healtText").GetComponent<Text>();
        timerText = transform.Find("timerText").GetComponent<Text>();
        caseText = transform.Find("caseText").GetComponent<Text>();
        retryButton = transform.Find("retryBtn").GetComponent<Button>();
    }

    // Restarts the game by loading the first scene.
    private void StartAgain()
    {
        SceneManager.LoadScene(0);
    }

    // Displays the "Game Not Completed" message and activates the retry button.
    public void GameNotCompleted()
    {
        UpdateText(TextEnum.Case, "Game Not Completed!");
        retryButton.gameObject.SetActive(true);
    }

    // Updates the corresponding text in the UI based on the TextEnum value.
    public void UpdateText(TextEnum textEnum, string textValue)
    {
        switch (textEnum)
        {
            case TextEnum.Healt:
                healtText.text = textValue;
                break;
            case TextEnum.Case:
                caseText.text = textValue;
                break;
            case TextEnum.Timer:
                timerText.text = textValue;
                break;
        }
    }
}
