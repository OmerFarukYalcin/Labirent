using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Reference to the UI Manager to handle UI updates.
    [SerializeField] private UiManager uiManager;

    // Reference to the finish object to be activated when the game is completed.
    [SerializeField] private GameObject finish;

    // Singleton instance of GameManager.
    public static GameManager instance;

    // Reference to the ball's transform.
    private Transform ballTf;

    // Timer for the game.
    private float timer;

    // Health reward for completing a level.
    private float rewardHealt = 1f;

    // Time reward for completing a level.
    private float rewardTime = 10f;

    // Property to track whether the game is over.
    public bool GameOver { get; private set; }

    private void Awake()
    {
        // Implement singleton pattern.
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        // Find the ball object by its tag and cache its transform.
        ballTf = GameObject.FindGameObjectWithTag("Ball").transform;

        // Load the saved timer value or default to 60 seconds.
        timer = PlayerPrefs.GetFloat("timer", 60);
    }

    private void Update()
    {
        // Quit the game if the Escape key is pressed.
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        // Update the timer if the game is not over.
        if (timer > 0 && !GameOver)
        {
            timer -= Time.deltaTime; // Decrease the timer.
            int _time = (int)timer; // Convert timer to an integer.
            uiManager.UpdateText(TextEnum.Timer, _time.ToString()); // Update the timer text in the UI.
        }
        else
        {
            // End the game when the timer reaches zero or the game is over.
            FinishTheGame();
        }
    }

    private void OnApplicationQuit()
    {
        // Deletes all saved PlayerPrefs data when the application quits.
        PlayerPrefs.DeleteAll();
    }

    // Ends the game and displays the "Game Not Completed" UI.
    public void FinishTheGame()
    {
        GameOver = true;

        uiManager.GameNotCompleted(); // Show the game not completed UI.

        PlayerPrefs.DeleteAll(); // Clear all saved data.
    }

    // Activates the finish object when the player collides with a game step.
    public void GameStepCollided()
    {
        finish.SetActive(true); // Activate the finish object.
    }

    // Loads the next level and applies rewards for health and time.
    public void NextLevel()
    {
        AddReward(); // Apply health and time rewards.

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next level.
    }

    // Adds health and time rewards when the player progresses to the next level.
    private void AddReward()
    {
        // Check if the ball has the BallHealt component.
        if (ballTf.TryGetComponent(out BallHealt ballHealt))
        {
            // Increase the player's health and clamp it between 0 and 5.
            float _healt = ballHealt.Healt + rewardHealt;
            _healt = Mathf.Clamp(_healt, 0, 5);

            // Add time reward.
            timer += rewardTime;

            // Save the updated health and timer values.
            PlayerPrefs.SetFloat("healt", _healt);
            PlayerPrefs.SetFloat("timer", timer);
        }
    }
}
