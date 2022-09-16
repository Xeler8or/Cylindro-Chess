using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f,1f,-5f);

    public Transform cylinder;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position + offset;
        var rotation_quaterion = new Quaternion(transform.rotation.x, transform.rotation.y, -cylinder.rotation.z,
            transform.rotation.w);
        transform.rotation = rotation_quaterion;
    }
}
