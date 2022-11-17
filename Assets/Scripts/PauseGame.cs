using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseDialogue;
    public GameObject buttonHide;

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseDialogue.SetActive(true);
    }

    public void hidePause()
    {   
        Debug.Log("herrrr");
        buttonHide.SetActive(false);
    }

    public void playGame()
    {
        Time.timeScale = 1;
        pauseDialogue.SetActive(false);
    }

    public void gotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void gotoTutorialMainPage()
    {
        SceneManager.LoadScene(3);
    }

    public void continueToActualGame()
    {
        Levels.SetCurrentLevel(Constants.ENDLESS);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    
    public void gotoLevelMainPage()
    {
        SceneManager.LoadScene(4);
    }
}
