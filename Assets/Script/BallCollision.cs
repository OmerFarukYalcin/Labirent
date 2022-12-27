using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{
    [SerializeField] GameManager gManager;

    bool _gameComplete;
    bool _gameRunning = true;

    private BallControl bControl;

    private void Start()
    {
        bControl= GetComponent<BallControl>();
    }

    public void SendGameBool(out bool _GameComplete , out bool _GameRunning)
    {
        _GameComplete = _gameComplete;
        _GameRunning = _gameRunning;
    }

    private void OnCollisionEnter(Collision cls)
    {
        string objName = cls.gameObject.name;
        if (objName.Equals("bitis"))
        {
            gManager.NextScene(SceneManager.GetActiveScene().buildIndex);
            GetComponent<BallHealt>().IncreaseHealt(1, 10);
        }
        else if (!objName.Equals("Zemin") && !objName.Equals("LabirentZemin") && !objName.Equals("first") && !objName.Equals("finish"))
        {
            GetComponent<BallHealt>().TakeDamage(1);
            _gameRunning = GetComponent<BallHealt>().IsDead();
        }
        if (objName.Equals("first"))
        {
            bControl.finish.gameObject.SetActive(true);

        }
        if (objName.Equals("finish") && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("bolum2"))
        {
            print("healt:" + BallControl.healt);
            print("time:" + BallControl.timeCounter);
            _gameComplete = true;
            gManager.sendDefaultValue(out BallControl.healt, out BallControl.timeCounter);
            gManager.NextScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
