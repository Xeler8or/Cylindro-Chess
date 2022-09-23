
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

public class PlayerController : MonoBehaviour
{
    private GameObject _currentPiece;
    public List<GameObject> pieces;
    public Constants.Pieaces piece;
    public Constants.Color color;
    public Rigidbody rb;
    private Vector3 _inertiaTensor = new Vector3(0f,0f,0f);
    public static float forwardForce;
    public GameObject restartPanel;
    private GameController _GMC;
    public int scoreIncrement = 1;
    public Dictionary<Constants.Pieaces, int> PieceRanking = new Dictionary<Constants.Pieaces, int>{
        {Constants.Pieaces.Pawn,0},
        {Constants.Pieaces.Knight,1},
        {Constants.Pieaces.Rook,2},
        {Constants.Pieaces.Queen,3},
        {Constants.Pieaces.King,4}
    };
    void Start()
    { 
        rb.inertiaTensor = _inertiaTensor;
        _GMC = FindObjectOfType<GameController>();
        piece = Constants.Pieaces.Pawn;
        color = Constants.Color.White;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player to move forward
        rb.AddForce(0,0,forwardForce);
        
        _GMC.score += scoreIncrement;
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Triggered");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            if (HandleColor(collision))
            {
                //If color opposite
                if (!HandlePiece(collision))    //Higher piece
                {
                    Restart();
                }
            }
            else
            {
                //If Color same
                Restart();
            }

        }
    }

    private void Restart()
    {
        Time.timeScale = 0;
        restartPanel.SetActive(true);
    }
    
    private Constants.Pieaces GetNextPiece(Constants.Pieaces piece)
    {
        switch (piece)
        {
            case Constants.Pieaces.Pawn:
                return Constants.Pieaces.Knight;
            case Constants.Pieaces.Knight:
                return Constants.Pieaces.Rook;
            case Constants.Pieaces.Rook:
                return Constants.Pieaces.King;
            default:
                return Constants.Pieaces.King;
        }
    }
    
    private bool HandleColor(Collider collision){
        if (collision.gameObject.GetComponent<ObstacleController>().color == this.color)
        {
            Debug.Log("SAME");
            return false;
        }
        return true;
    }
    
    private bool HandlePiece(Collider collision)
    {
        return true;
    }
}