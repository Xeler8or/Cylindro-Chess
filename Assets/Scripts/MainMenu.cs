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
        Levels.SetCurrentLevel("ENDLESS");
        PauseGame.continueGame();
        SceneManager.LoadScene(1);
    }

    public void LoadTutorials()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadTutorial(string tutorialName)
    {
        GameTutorial.startTutorial();
        Levels.SetCurrentLevel(tutorialName);
        PauseGame.continueGame();
        SceneManager.LoadScene(2);
    }

    public void LoadLevels()
    {
        SceneManager.LoadScene(4);
    }
    
    public void LoadLevel(string levelName)
    {
        Levels.SetCurrentLevel(levelName);
        PauseGame.continueGame();
        SceneManager.LoadScene(1);
    }
}
