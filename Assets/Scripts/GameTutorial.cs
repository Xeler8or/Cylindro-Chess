using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameTutorial : MonoBehaviour
{
    public GameObject tutorialBackground;
    public GameObject endGame;
    public TextMeshProUGUI tutorialText;
    private int tutorialIndex = 0;
    private static bool showText = false;
    private string[] tutorialTexts = new string[]{ Constants.MOVE_LEFT_RIGHT, 
                                                   Constants.CHANGE_SHAPE,
                                                   Constants.CHANGE_TO_CUBE,
                                                   Constants.COLOR_CHANGE,
                                                   Constants.PASS_THROUGH_RED_PORTION,
                                                   Constants.AUTOMATIC_RIGHT_SECTION,
                                                   Constants.LOCK_TUTORIAL,
                                                   Constants.ROTATE_RIGHT_360,
                                                   Constants.ROTATE_LEFT_360,
                                                   Constants.PERFORM_ON_LOCK,
                                                   Constants.COLLECT_COINS_FOR_POWERUPS,
                                                   Constants.COLLECT_RAINBOW_POWERUP,
                                                   Constants.COLLECT_SLOWDOWN_POWERUP,
                                                   Constants.BOUNCE_OBSTACLE,
                                                   Constants.TURN_RIGHT_INSIDE_BOUNCE,
                                                   Constants.PORTALS,
                                                   Constants.HEALTH
    };

    static bool _EndTutorial = false;

    // Update is called once per frame
    void Update()
    {
        if (_EndTutorial)
        {
            tutorialBackground.SetActive(false);
            endGame.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        
        if (showText && tutorialIndex < tutorialTexts.Length)
        {
            tutorialBackground.SetActive(true);
            Time.timeScale = 0;
            tutorialText.text = tutorialTexts[tutorialIndex];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialBackground.SetActive(false);
                showText = false;
                tutorialIndex++;
            }
        }
        else if ( !showText && tutorialIndex < tutorialTexts.Length )
        {
            tutorialBackground.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public static void showTutorial()
    {
        _EndTutorial = false;
        showText = true;
    }

    public static void endTutorial()
    {
        _EndTutorial = true;
    }
}
