using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        print(tutorialName);
        if (tutorialName == "MOVEMENT")
        {
            
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
        else if (tutorialName == "DEFAULT_LEFT")
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
