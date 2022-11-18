using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 innerCylinderOffset = new Vector3(0f,5f,-10f);
    private Vector3 outerCylinderOffset = new Vector3(0f, -3f, -10f);
    private Vector3 lockZoneOffset = new Vector3(0f, 25f, 0f);

    private Vector3 animationOffset;
    // private Vector3 lockZoneOffset = new Vector3(0f, 15f, -20f);
    // Initial Camera (10, 0, 0)
    private PlayerController _player;
    private bool _cameraRotate = false;
    private float factor = 150f;
    private float factor2 = 150f;
    private int counter = 1;
    private float trans_y;
    private float trans_z;
    private float trans_x;
    private float final_y = 25;
    private float initial_y = 5;
    private float final_x = 0;
    private float initial_x = 0;   
    private float final_z = -10;
    private float initial_z = 0;   
    private bool once = false;
    private float final_cam_y = 0;
    private float initial_cam_y = 0;
    private float final_cam_x = 65;
    private float initial_cam_x = 10;   
    private float final_cam_z = 0;
    private float initial_cam_z = 0;

    private float rot_y;

    private float rot_z;

    private float rot_x;
    // Update is called once per frame
    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        trans_y = (final_y - initial_y) / factor;
        trans_z = (final_z - initial_z) / factor;
        trans_x = (final_x - initial_x) / factor;
        rot_y = (final_cam_y - initial_cam_y) / factor2;
        rot_z = (final_cam_z - initial_cam_z) / factor2;
        rot_x = (final_cam_x - initial_cam_x) / factor2;
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
                if (!_player.platformRotate)
                {
                    if (counter < factor)
                    {
                        animationOffset = new Vector3(counter * trans_x, counter * trans_y, counter * trans_z);
                        transform.position = player.position + innerCylinderOffset + new Vector3(counter*trans_x, counter*trans_y, counter*trans_z);
                        
                        print(counter);
                        print(transform.position);
                    }
                    else
                    {
                        // print("Hei");
                        transform.position = player.position + lockZoneOffset;
                    }
                    
                }
                else
                {
                    transform.position = player.position + innerCylinderOffset;
                    counter = 1;
                }
            }
            if (!_player.platformRotate && !_cameraRotate)
            {
                if (counter < factor2)
                {
                    transform.localEulerAngles = new Vector3(initial_cam_x + counter*rot_x, initial_cam_y + counter*rot_y, initial_cam_z + counter*rot_z);
                    print("Rotation");
                    print(transform.rotation.eulerAngles);
                    counter += 1;

                }
                else
                {
                    _cameraRotate = true;
                    // transform.localEulerAngles = new Vector3(65, 0, 0);
                    // transform.position = player.position + lockZoneOffset;
                    // transform.localRotation = Quaternion.Euler(3, 0, 45);
                    // once = true;
                }

            }

            if (_player.platformRotate && _cameraRotate)
            {
                _cameraRotate = false;
                transform.Rotate(-40f,0f,0f);
            }

            // if (!_player.platformRotate && !once)
            // {
            //     transform.Rotate(30f,0f,0f);
            //     once = true;
            // }
            //
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
