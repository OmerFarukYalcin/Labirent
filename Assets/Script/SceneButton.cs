using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void StartAgain()
    {
        SceneManager.LoadScene(0);
    }
}
