using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_path : MonoBehaviour
{
    private Vector3 _rotation = new Vector3(0,1,0);
    public float speed = 80f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation * speed * Time.deltaTime);
    }
}