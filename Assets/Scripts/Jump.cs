using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Jump : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;
    public float jumpForce = 400f;
    private bool _canDoubleJump ;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate ()
    {

        //Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(0, 0, speed);
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("yes");
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Acceleration);
            //rb.velocity = Vector3.up * jumpForce;
            //_canDoubleJump = !_canDoubleJump;
        }
        */
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        if (isGrounded && !Input.GetButton("Jump"))
        {
            _canDoubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || _canDoubleJump)
            {
                rb.AddForce(Vector3.up*jumpForce);
                _canDoubleJump = !_canDoubleJump;
            }
        }
        

    }

    
    void JumpFunc()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity * 0.3f;
        }
    }
    
}
