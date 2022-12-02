using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    private float rightRotation = 100f;
    private float leftRotation = 100f;
    private float outerLeftRotation = 50f;
    private float outerRightRotation = 50f;

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
                if (PlayerController.onOuterCylinder)
                {
                    transform.Rotate(0f,outerLeftRotation * Time.deltaTime,0f, Space.Self);
                }
                else
                {
                    transform.Rotate(0f, leftRotation * Time.deltaTime, 0f, Space.Self);
                }

                if(childRotator)
                    childRotator.transform.Rotate(0, 2f*leftRotation*Time.deltaTime,0, Space.Self);
            }
            if(Input.GetKey("a") || Input.GetKey("left"))
            {
                // Rotate cylinder to right
                if (PlayerController.onOuterCylinder)
                {
                    transform.Rotate(0f, -outerRightRotation * Time.deltaTime, 0f, Space.Self);                }
                else
                {
                    transform.Rotate(0f, -rightRotation * Time.deltaTime, 0f, Space.Self);
                }

                if(childRotator)
                    childRotator.transform.Rotate(0, -2f*rightRotation*Time.deltaTime,0, Space.Self);
            }

        }
        
    }
}
