using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    public Transform ground;
    public float rightRotation = 200f;
    public float leftRotation = 200f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            //Rotate cylinder to left
            ground.Rotate(0f,-leftRotation * Time.deltaTime,0f, Space.Self);
        }
        if(Input.GetKey("a"))
        {
            // Rotate cylinder to right
            ground.Rotate(0f,rightRotation * Time.deltaTime, 0f, Space.Self);
        }
    }
}
