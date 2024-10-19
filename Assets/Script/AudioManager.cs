using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Static variable to ensure that the music persists across scenes.
    private static bool audioInScene;

    private void Start()
    {
        // If there isn't already a audio manager in the scene, keep this one and ensure it persists across scenes.
        if (!audioInScene)
        {
            DontDestroyOnLoad(this.gameObject); // Prevent this object from being destroyed when a new scene is loaded.
            audioInScene = true;  // Mark that the audio manager is now in the scene.
        }
        else
        {
            // If there's already a audio manager in the scene, destroy this duplicate.
            Destroy(this.gameObject);
        }
    }
}
