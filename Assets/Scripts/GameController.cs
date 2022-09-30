using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int _score = 0;
    private bool _isKing;

    public void SetScore(int score)
    {
        _score = score;
    }

    public int GetScore()
    {
        return _score;
    }
    
    public void SetisKing(bool isKing)
    {
        _isKing = isKing;
    }

    public bool GetisKing()
    {
        return _isKing;
    }
    
    public void Replay(){
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
