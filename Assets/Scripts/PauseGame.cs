using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseDialogue;

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseDialogue.SetActive(true);
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
}
