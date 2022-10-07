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
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            //Rotate cylinder to left
            ground.Rotate(0f,leftRotation * Time.deltaTime,0f, Space.Self);
            rotateRight += leftRotation * Time.deltaTime;
            Debug.Log("right rotations: "+(int)(rotateRight/360.0));
        }
        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            // Rotate cylinder to right
            ground.Rotate(0f,-rightRotation * Time.deltaTime, 0f, Space.Self);
            rotateLeft += -rightRotation * Time.deltaTime;
            Debug.Log("left rotations: "+(int)(rotateLeft/360.0));
        }
        // lock code text => 2R, 2L
        if ((int)(rotateRight/360.0) == 2 && (int)(rotateLeft/360.0) == -2)
        {
            Destroy(ground.transform.GetChild(0).gameObject);   
        }
    }
}
