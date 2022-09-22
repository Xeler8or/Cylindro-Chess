using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popupIndex = 0;

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
            PlayerController.forwardForce = 0f;
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popupIndex++;
            }
        }
        else if (popupIndex == 1)
        {
            PlayerController.forwardForce = 0f;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                popupIndex++;
            }
        }
        else if (popupIndex == 2)
        {
            popUps[popupIndex-1].SetActive(false);
            PlayerController.forwardForce = Constants.PLAYER_FORCE_Z;
        }
    }
}
