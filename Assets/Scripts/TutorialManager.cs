using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popupIndex = 0;
    public TextMeshProUGUI genericMessage;

    void Update()
    {
        if (popupIndex < popUps.Length)
        {
            for (int i = 0; i < popUps.Length; i++)
            {
                if (i == popupIndex)
                {
                    popUps[i].SetActive(true);
                }
                else
                {
                    popUps[i].SetActive(false);
                }
            }   
        }
        if (popupIndex == 0)
        {
            PlayerController.setVelocity(0f);
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popupIndex++;
            }
        }
        else if (popupIndex == 1)
        {
            PlayerController.setVelocity(0f);
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                popupIndex++;
            }
        }
        else if (popupIndex is 2 or 3 or 4 or 5)
        {
            PlayerController.setVelocity(0f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popupIndex++;
            }
        }
        else if (popupIndex == 6)
        {
            popUps[popupIndex-1].SetActive(false);
            showMessage(Constants.COLLECT_A_PAWN);
        }
        else if (popupIndex is 7 or 8 or 9 or 10 or 11 or 12)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                genericMessage.gameObject.SetActive(false);
                PlayerController.setVelocity(Constants.PLAYER_VELOCITY_Z);
            }
        }
        else
        {
            genericMessage.gameObject.SetActive(false);
            PlayerController.setVelocity(Constants.PLAYER_VELOCITY_Z);
        }
    }

    public void showMessage(String message)
    {
        genericMessage.text = message;
        genericMessage.gameObject.SetActive(true);
        PlayerController.setVelocity(0f);
        popupIndex++;
    }
}
