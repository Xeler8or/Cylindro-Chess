using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LockRotator2 : MonoBehaviour
{
    public float rightRotation = 200f;
    public float leftRotation = 200f;
    public float rotateRight = 0f;
    public float rotateLeft = 0f;
    private LockRotator lock1;
    public bool lock3Rotate = false;
    public bool dir = true;
    // True == Right
    // public GameObject instructions;

    private void Start()
    {
        lock1 = FindObjectOfType<LockRotator>();
    }
    
    

    void Update()
    {
        if (lock1.lock2Rotate && lock1.dir)
        {
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                // instructions.SetActive(false);
                //Rotate cylinder to left
                transform.Rotate(0f, leftRotation * Time.deltaTime, 0f, Space.Self);
                rotateRight += leftRotation * Time.deltaTime;
                // rotateLeft += leftRotation * Time.deltaTime;;
                dir = true;
                // Debug.Log("right rotations: "+rotateRight);
                // Debug.Log("right rotations: " + (int)(rotateRight / 360.0));
                if (!lock3Rotate)
                {
                    dir = true;
                }
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

        if (lock1.lock2Rotate && !lock1.dir)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                // Rotate cylinder to right
                // instructions.SetActive(false);
                transform.Rotate(0f, -rightRotation * Time.deltaTime, 0f, Space.Self);
                rotateLeft += -rightRotation * Time.deltaTime;
                // rotateRight -= rightRotation * Time.deltaTime;;
                dir = false;
                // Debug.Log("left rotations: "+rotateLeft);
                // Debug.Log("left rotations: " + (int)(rotateLeft / 360.0));
            }
            
            if (!lock3Rotate)
            {
                dir = false;
            }
        }

        

    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lock3"))
        {
            // Instantiate(lockRotator,
            //     new Vector3(transform.position.x, transform.position.y-5f, transform.position.z + 20f), Quaternion.Euler(new Vector3(-90f,0f,0f)));
            lock3Rotate = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        lock3Rotate = false;
    }
}
