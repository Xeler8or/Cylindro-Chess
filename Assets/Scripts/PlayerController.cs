
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private GameObject _currentPiece;
    public List<GameObject> pieces;
    public Constants.Pieaces piece;
    public Constants.Color color;
    public Rigidbody rb;
    private Vector3 _inertiaTensor = new Vector3(0f,0f,0f);
    public static float forwardForce;
    public GameObject gmController;
    public GameObject restartPanel;
    private GameController _GMC;
    public int scoreIncrement = 1;
    void Start()
    { 
        rb.inertiaTensor = _inertiaTensor;
        _GMC = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player to move forward
        rb.AddForce(0,0,forwardForce);
        _GMC.score += scoreIncrement;
        Debug.Log(_GMC.score);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Restart
            Time.timeScale = 0;
            restartPanel.SetActive(true);
        }
    }
}
