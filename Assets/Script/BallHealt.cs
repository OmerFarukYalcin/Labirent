using UnityEngine;

public class BallHealt : MonoBehaviour
{
    // Reference to the UI Manager to update the health display.
    [SerializeField] private UiManager uiManager;

    // Variable to store the ball's health.
    private float healt;

    private void Awake()
    {
        // Load the health value from PlayerPrefs, with a default value of 5 if not previously saved.
        healt = PlayerPrefs.GetFloat("healt", 5);

        // Update the UI with the current health value.
        uiManager.UpdateText(TextEnum.Healt, healt.ToString());
    }

    // Method to reduce the ball's health by a specified amount.
    public void TakeDamage(int _amount)
    {
        // Subtract the damage amount from the health.
        healt -= _amount;

        // Update the UI with the new health value.
        uiManager.UpdateText(TextEnum.Healt, healt.ToString());

        // If the health drops to zero or below, trigger the game over logic.
        if (healt <= 0)
        {
            GameManager.instance.FinishTheGame();
        }
    }

    // Public property to get the current health value.
    public float Healt => healt;
}
