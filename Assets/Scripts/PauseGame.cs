using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseDialogue;
    public GameObject buttonHide;

    public static void stopGame()
    {
        Time.timeScale = 0;
    }

    public static void continueGame()
    {
        Time.timeScale = 1;
    }
    
    public void pauseGame()
    {
        stopGame();
        pauseDialogue.SetActive(true);
    }

    public void hidePause()
    {
        buttonHide.SetActive(false);
    }

    public void showPause()
    {
        buttonHide.SetActive(true);
    }

    public void playGame()
    {
        continueGame();
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
        continueGame();
    }
    
    public void gotoLevelMainPage()
    {
        SceneManager.LoadScene(4);
    }
}
