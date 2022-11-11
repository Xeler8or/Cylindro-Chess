using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 innerCylinderOffset = new Vector3(0f,5f,-10f);
    private Vector3 outerCylinderOffset = new Vector3(0f, -3f, -10f);
    private Vector3 lockZoneOffset = new Vector3(0f, 15f, -20f);
    private PlayerController _player;

    private bool once = false;
    // Update is called once per frame
    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (transform != null)
        {
            if (PlayerController.onOuterCylinder)
            { 
                transform.position = player.position + outerCylinderOffset;
            }
            else
            {
                transform.position = player.position + innerCylinderOffset;
            }
            if (!_player.platformRotate)
            {
                transform.position = player.position + lockZoneOffset;
                // transform.Rotate(40f,0f,0f);
                // once = true;

            }

            // if (!_player.platformRotate && !once)
            // {
            //     transform.Rotate(30f,0f,0f);
            //     once = true;
            // }

            // if (_player.platformRotate)
            // {   
            //     transform.position = player.position + innerCylinderOffset;
            //     // transform.Rotate(-30f,0f,0f);
            //     // once = false;
            // }

            // if (_player.platformRotate && once)
            // {
            //     transform.Rotate(-30f,0f,0f);
            // }
            // else if(_player.platformRotate)
            // {
            //     transform.position = player.position + innerCylinderOffset;
            // }
        }
        

    }
}
