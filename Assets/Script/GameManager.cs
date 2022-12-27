using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int tempNum=0;
    float _timeCounter = 60;
    int _healt = 5;

    public void sendDefaultValue(out int _Healt, out float _TimeCounter)
    {
        _Healt = _healt;
        _TimeCounter = _timeCounter;
    }

    public void NextScene(int _sceneNum)
    {
        tempNum = _sceneNum;
        tempNum += 1;
        SceneManager.LoadScene(tempNum);
    }
}
