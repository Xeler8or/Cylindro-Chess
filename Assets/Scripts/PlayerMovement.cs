
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 InertiaTensor = new Vector3(0f,0f,0f);
    public float forwardForce = 200f;
   
    void Start()
    {
        rb.inertiaTensor = InertiaTensor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.AddForce(0,0,forwardForce);   
      
        
    }
}
