using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    // Reference to the UI text component to display the final message.
    [SerializeField] private Text caseText;

    // Reference to the retry button.
    [SerializeField] private Button retryButton;

    private void Start()
    {
        // Display the completion message.
        caseText.text = "You have completed the game. Congratulations!";

        // Make the retry button visible.
        retryButton.gameObject.SetActive(true);

        // Add a listener to the retry button to reload the first scene when clicked.
        retryButton.onClick.AddListener(() => SceneManager.LoadScene(0));

        // Clear all player preferences to reset any saved data.
        PlayerPrefs.DeleteAll();
    }
}
