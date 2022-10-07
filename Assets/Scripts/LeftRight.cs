using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    public Transform ground;
    public float rightRotation = 200f;
    public float leftRotation = 200f;
    public float rotateRight = 0f;
    public float rotateLeft = 0f;
    public static bool rotateFlag = true;

    // Update is called once per frame
    void Update()
    {
        if (rotateFlag)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                //Rotate cylinder to left
                ground.Rotate(0f,leftRotation * Time.deltaTime,0f, Space.Self);

            }
            if(Input.GetKey("a") || Input.GetKey("left"))
            {
                // Rotate cylinder to right
                ground.Rotate(0f,-rightRotation * Time.deltaTime, 0f, Space.Self);

            }

        }
        
    }
}
