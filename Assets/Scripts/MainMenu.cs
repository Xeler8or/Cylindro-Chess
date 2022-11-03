using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static bool tutorialDone = false;
    public void LoadNewGame()
    {
        Time.timeScale = 1;
        if (tutorialDone)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            tutorialDone = true;
            SceneManager.LoadScene(2);
        }
    }

    public void LoadTutorial()
    {
        tutorialDone = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
