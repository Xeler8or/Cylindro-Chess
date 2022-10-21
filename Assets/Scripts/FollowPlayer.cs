using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 innerCylinderOffset = new Vector3(0f,5f,-10f);
    private Vector3 outerCylinderOffset = new Vector3(0f, -3f, -10f);

    // Update is called once per frame
    void Update()
    {
        if (transform != null)
            if (PlayerController.onOuterCylinder)
                transform.position = player.position + outerCylinderOffset;
            else
                transform.position = player.position + innerCylinderOffset;
    }
}
