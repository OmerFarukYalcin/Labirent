using UnityEngine;

public class backGround : MonoBehaviour
{
    static bool musicInScene;
    void Start()
    {
        if (!musicInScene)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            musicInScene = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
