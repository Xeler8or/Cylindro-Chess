
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 inertiaTensor = new Vector3(0f,0f,0f);
    public float forwardForce = 10f;

    void Start()
    { 
        rb.inertiaTensor = inertiaTensor;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player to move forward
        rb.AddForce(0,0,forwardForce);
    }
}
