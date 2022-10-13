using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTutorial : MonoBehaviour
{
    public GameObject tutorialBackground;
    public TextMeshProUGUI tutorialText;
    private int tutorialIndex = 0;
    private string[] tutorialTexts = new string[]{ Constants.MOVE_LEFT_RIGHT, 
                                       Constants.CHANGE_SHAPE,
                                       Constants.COLOR_CHANGE,
                                       Constants.AUTOMATIC_RIGHT_SECTION,
                                       Constants.LOCK_TUTORIAL };

    // Update is called once per frame
    void Update()
    {
        if (tutorialIndex < tutorialTexts.Length)
        {
            PlayerController.Velocity = 0f;
            tutorialText.text = tutorialTexts[tutorialIndex];
            if (Input.GetKeyDown(KeyCode.Space))
                tutorialIndex++;
        }
        else
        {
            tutorialBackground.SetActive(false);
            PlayerController.Velocity = Constants.INITIAL_PLAYER_SPEED;
        }
    }
}
