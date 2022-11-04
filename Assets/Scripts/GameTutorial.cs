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
    private static int _tutorialIndex = 0;
    private static bool _showText = false;
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
                                                   Constants.HEALTH,
                                                   Constants.PORTALS,
                                                   Constants.UP_SIDE_DOWN
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
        
        if (_showText && _tutorialIndex < tutorialTexts.Length)
        {
            tutorialBackground.SetActive(true);
            Time.timeScale = 0;
            tutorialText.text = tutorialTexts[_tutorialIndex];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialBackground.SetActive(false);
                _showText = false;
                _tutorialIndex++;
            }
        }
        else if ( !_showText && _tutorialIndex <= tutorialTexts.Length )
        {
            tutorialBackground.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public static void showTutorial()
    {
        _showText = true;
    }

    public static void endTutorial()
    {
        _EndTutorial = true;
    }

    public static void startTutorial()
    {
        _EndTutorial = false;
    }

    public static void setTutorialIndex( int tutorialIndex )
    {
        _tutorialIndex = tutorialIndex;
    }
}
