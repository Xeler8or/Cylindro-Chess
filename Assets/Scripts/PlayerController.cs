using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private readonly Vector3 _inertiaTensor = new Vector3(0f,0f,0f);
    public static float Velocity;
    [SerializeField]
    private GameObject restartPanel;
    private GameController gmc;
    [SerializeField]
    private float _initalPos = 0;
    [SerializeField]
    private Constants.Color color;
    // Start is called before the first frame update
    void Start()
    {
        Velocity = 10f;
        rb.inertiaTensor = _inertiaTensor;
        gmc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        gmc.SetScore((int)(transform.position.z - _initalPos));
    }
    
    private void Restart()
    {
        Time.timeScale = 0;
        restartPanel.SetActive(true);
        SendToGoogle.Instance.Send();
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0,0,Velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<ObstacleController>().color != color)
            {
                Restart();
            }
        }
    }
}
