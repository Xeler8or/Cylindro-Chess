using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(10f,3f,-10f);

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform!=null)
            transform.position = player.position + offset;
    }
}
