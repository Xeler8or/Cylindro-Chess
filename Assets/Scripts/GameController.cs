using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int _score = 0;

    public void SetScore(int score)
    {
        _score = score;
    }

    public int GetScore()
    {
        return _score;
    }
}
