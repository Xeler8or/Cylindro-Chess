using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 _inertiaTensor = new Vector3(0f,0f,0f);
    public static float velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = 10f;
        rb.inertiaTensor = _inertiaTensor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0,0,velocity);
    }
}
