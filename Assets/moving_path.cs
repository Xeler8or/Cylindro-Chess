using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_path : MonoBehaviour
{
    public Vector3 _rotation;
    public float _speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }
}