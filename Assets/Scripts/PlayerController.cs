
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 inertiaTensor = new Vector3(0f,0f,0f);
    public float forwardForce = 10f;

    public GameObject restartPanel;

    void Start()
    { 
        rb.inertiaTensor = inertiaTensor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player to move forward
        rb.AddForce(0,0,forwardForce);
        
        //Pause if player falls
        if(this.gameObject.transform.position.y < 4.5f)
        {
            //Restart
            Time.timeScale = 0;
            restartPanel.SetActive(true);
        }
    }
}
