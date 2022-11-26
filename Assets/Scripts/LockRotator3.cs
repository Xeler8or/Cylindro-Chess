using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LockRotator3 : MonoBehaviour
{
    public float rightRotation = 200f;
    public float leftRotation = 200f;
    public float rotateRight = 0f;
    public float rotateLeft = 0f;
    private LockRotator2 lock2;
    
    // True == Right
    // public GameObject instructions;

    private void Start()
    {
        lock2 = FindObjectOfType<LockRotator2>();
    }
    
    

    void Update()
    {
        if (lock2.lock3Rotate && lock2.dir)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                // instructions.SetActive(false);
                //Rotate cylinder to left
                transform.Rotate(0f, leftRotation * Time.deltaTime, 0f, Space.Self);
                rotateRight += leftRotation * Time.deltaTime;
                // rotateLeft += leftRotation * Time.deltaTime;;

                // Debug.Log("right rotations: "+rotateRight);
                // Debug.Log("right rotations: " + (int)(rotateRight / 360.0));
            }

            
            // lock code text => 2R, 2L


            // if ((int)(rotateRight / 360.0) == 2 && (int)(rotateLeft / 360.0) == -2)
            // {
            //     Destroy(gameObject);
            //     _player.ContinuePlay();
            //     instructions.SetActive(true);
            //
            // }
            
        }

        if (lock2.lock3Rotate && !lock2.dir)
        {
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                // Rotate cylinder to right
                // instructions.SetActive(false);
                transform.Rotate(0f, -rightRotation * Time.deltaTime, 0f, Space.Self);
                rotateLeft += -rightRotation * Time.deltaTime;
                // rotateRight -= rightRotation * Time.deltaTime;;

                // Debug.Log("left rotations: "+rotateLeft);
                // Debug.Log("left rotations: " + (int)(rotateLeft / 360.0));
            }
        }

        

    }
    
    

}
