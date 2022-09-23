
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.Collections;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    private GameObject _currentPiece;
    public Constants.Pieaces piece;
    public Constants.Color color;
    public Rigidbody rb;
    private Vector3 _inertiaTensor = new Vector3(0f,0f,0f);
    public static float velocity = 10;
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
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player to move forward
        rb.velocity = new Vector3(0,0,velocity);
        
        _GMC.SetScore(_GMC.GetScore() + scoreIncrement);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
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
        Debug.Log("Color checking");
        if (collision.gameObject.GetComponent<ObstacleController>().color == color)
        {
            Debug.Log("Color same");
            return false;
        }
        return true;
    }

    private void ShowPromotionEffect()
    {
        //Instantiate Particle Effect
    }
    
    private void ShowParticleEffect()
    {
        //Instantiate Particle Effect   
    }
    private void TriggerPiecePrefab(Constants.Pieaces pieace)
    {
        bool currState = gameObject.transform.GetChild(PieceRanking[pieace]).gameObject.activeSelf;
        gameObject.transform.GetChild(PieceRanking[pieace]).gameObject.SetActive(!currState);
    }
    
    private bool HandlePiece(Collider collision)
    {
        Constants.Pieaces obstaclePiece = collision.gameObject.GetComponent<ObstacleController>().piece;
        if (collision.gameObject.GetComponent<ObstacleController>().piece == piece) //FOR NOW JUST ADDED 1 PER PIECE FOR PROMOTION
        {
            TriggerPiecePrefab(piece);
            piece = GetNextPiece(piece);
            if (piece != Constants.Pieaces.King)    //Update only if not King
            {
                ShowPromotionEffect();
                TriggerPiecePrefab(piece);
            }
        }
        else if(PieceRanking[piece] > PieceRanking[obstaclePiece])
        {
            ShowParticleEffect();
            Destroy(collision.gameObject);
        }
        else
        {
            ShowParticleEffect();
            //Destroy(gameObject);
            return false;
        }
        return true;
    }
}