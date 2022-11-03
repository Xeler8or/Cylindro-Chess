using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    public float rightRotation = 150f;
    public float leftRotation = 150f;
    public GameObject childRotator;

    private PlayerController _playerController;
    // // Update is called once per frame
    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (_playerController.platformRotate)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                //Rotate cylinder to left
                transform.Rotate(0f,leftRotation * Time.deltaTime,0f, Space.Self);
                if(childRotator)
                    childRotator.transform.Rotate(0, 2*leftRotation*Time.deltaTime,0, Space.Self);
            }
            if(Input.GetKey("a") || Input.GetKey("left"))
            {
                // Rotate cylinder to right
                transform.Rotate(0f,-rightRotation * Time.deltaTime, 0f, Space.Self);
                if(childRotator)
                    childRotator.transform.Rotate(0, -2*rightRotation*Time.deltaTime,0, Space.Self);
            }

        }
        
    }
}
