using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private TileManager _tileManager;

    void Start()
    {
        _tileManager = FindObjectOfType<TileManager>();
    }

    public void LoadNewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadTutorials()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadTutorial(string tutorialName)
    {
        if (tutorialName == "MOVEMENT")
        {
            Levels.SetCurrentLevel(tutorialName);
        }
        else if (tutorialName == "SHAPE")
        {
            
        }
        else if (tutorialName == "COLOR")
        {
            
        }
        else if (tutorialName == "DEFAULT_LEFT")
        {
            
        }
        else if (tutorialName == "LOCK")
        {
            
        }
        else if (tutorialName == "COINS")
        {
            
        }
        else if (tutorialName == "BOUNCE")
        {
            
        }
        else if (tutorialName == "HEALTH")
        {
            
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
