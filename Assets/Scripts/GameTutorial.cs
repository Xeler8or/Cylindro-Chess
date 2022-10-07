using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTutorial : MonoBehaviour
{
    public GameObject gameTutorialText;

    private float initialTime = Time.time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)(7 - Time.time + initialTime) == 0)
        {
            print("Here");
            gameTutorialText.SetActive(false);
        }
    }
}
