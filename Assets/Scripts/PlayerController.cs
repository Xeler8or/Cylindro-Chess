
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.Collections;
using Unity.VisualScripting;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameObject _currentPiece;
    public Constants.Pieaces piece;
    public Constants.Color color;
    public Rigidbody rb;
    private Vector3 _inertiaTensor = new Vector3(0f,0f,0f);
    public static float velocity;
    public GameObject restartPanel;
    private GameController _GMC;
    public int scoreIncrement = 1;
    public GameObject _PowerButton;
    public GameObject _PowerCountDown;
    public TextMeshProUGUI _PowerCountTime;
    public bool powerActive = false;
    public float PowerStart;
    public Dictionary<Constants.Pieaces, int> PieceRanking = new Dictionary<Constants.Pieaces, int>{
        {Constants.Pieaces.Pawn,0},
        {Constants.Pieaces.Knight,1},
        {Constants.Pieaces.Rook,2},
        {Constants.Pieaces.Queen,3},
        {Constants.Pieaces.King,4}
    };

    private TutorialManager _tutorialManager;
    
    void Start()
    { 
        rb.inertiaTensor = _inertiaTensor;
        _GMC = FindObjectOfType<GameController>();
        piece = Constants.Pieaces.Pawn;
        color = Constants.Color.White;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        _tutorialManager = FindObjectOfType<TutorialManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player to move forward
        rb.velocity = new Vector3(0,0,velocity);
        int multFactor = 1;
        if (piece == Constants.Pieaces.King)
            multFactor = 2;
        _GMC.SetScore(_GMC.GetScore() + multFactor*scoreIncrement);
        ManagePower();
        if (Input.GetKey("e") || Input.GetKey("?"))
        {
            if (piece == Constants.Pieaces.King)
            {
                UsePower();
            }
        }
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
                    _tutorialManager.showMessage(Constants.END_GAME_HIGHER_POWER);
                    Restart();
                }
            }
            else
            {
                //If Color same
                if (powerActive == false && !HandleSameColorPiece(collision))
                {
                    _tutorialManager.showMessage(Constants.END_GAME_SAME_COLOR);
                    Restart();
                }
            }

        }
    }

    private void Restart()
    {
        Time.timeScale = 0;
        restartPanel.SetActive(true);
        SendToGoogle.Instance.Send();
        Destroy(gameObject);
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
                return Constants.Pieaces.Queen;
            case Constants.Pieaces.Queen:
                return Constants.Pieaces.King;
            default:
                return Constants.Pieaces.King;
        }
    }
    
    private Constants.Pieaces GetPrevPiece(Constants.Pieaces piece)
    {
        switch (piece)
        {
            case Constants.Pieaces.Knight:
                return Constants.Pieaces.Pawn;
            case Constants.Pieaces.Rook:
                return Constants.Pieaces.Knight;
            case Constants.Pieaces.Queen:
                return Constants.Pieaces.Rook;
            case Constants.Pieaces.King:
                return Constants.Pieaces.Queen;
            default:
                return Constants.Pieaces.Pawn;
        }
    }
    
    private bool HandleColor(Collider collision){
        if (collision.gameObject.GetComponent<ObstacleController>().color == color)
        {
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
        if (collision.gameObject.GetComponent<ObstacleController>().piece ==
            piece) //FOR NOW JUST ADDED 1 PER PIECE FOR PROMOTION
        {
            if (piece != Constants.Pieaces.King) //Update only if not King
            {
                TriggerPiecePrefab(piece);
                piece = GetNextPiece(piece);
                print(piece);
                ShowPromotionEffect();
                Destroy(collision.gameObject);
                TriggerPiecePrefab(piece);
                if (piece == Constants.Pieaces.Knight)
                {
                    _tutorialManager.showMessage(Constants.UPGRADE_TO_KNIGHT);
                }
                else if (piece == Constants.Pieaces.Rook)
                {
                    _tutorialManager.showMessage(Constants.UPGRADE_TO_ROOK);
                }
                else if (piece == Constants.Pieaces.Queen)
                {
                    _tutorialManager.showMessage(Constants.UPGRADE_TO_QUEEN);
                }
                else if (piece == Constants.Pieaces.King)
                {
                    _tutorialManager.showMessage(Constants.UPGRADE_TO_KING);
                    _PowerButton.SetActive(true);
                }
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
            return false;
        }
        return true;
    }
    
    private bool HandleSameColorPiece(Collider collision)
    {
        Constants.Pieaces obstaclePiece = collision.gameObject.GetComponent<ObstacleController>().piece;

        if (piece != Constants.Pieaces.Pawn) //Update only if not Pawn
        {
            DisablePower();
            TriggerPiecePrefab(piece);
            piece = GetPrevPiece(piece);
            Destroy(collision.gameObject);
            TriggerPiecePrefab(piece);
        }
        else
        {
            ShowParticleEffect();
            return false;
        }
        return true;
    }

    
    public static void setVelocity(float inVelocity)
    {
        velocity = inVelocity;
    }
    
    public void UsePower(){
        powerActive = true;
        // Debug.Log("Power is now active for 10 seconds");
        _PowerCountDown.SetActive(true);
        // _PowerCountTime.text = "Time Left : 10";
        PowerStart = Time.time;
    }

    public void DisablePower(){
        _PowerButton.SetActive(false);
        powerActive = false;
        //Debug.Log("Power is now active for 10 seconds");
        _PowerCountDown.SetActive(false);
        _PowerCountTime.text = "";
        //PowerStart = Time.time;
    }

    public void ManagePower(){
        if (powerActive) {
            _PowerCountTime.text = "Time Left : " + (10 - Time.time + PowerStart).ToString("#.#");
            if (Time.time - PowerStart >= 10.0) 
            {
                //Debug.Log("Power Over");
                powerActive = false;
                TriggerPiecePrefab(piece);
                piece = Constants.Pieaces.Pawn;
                ShowPromotionEffect();
                TriggerPiecePrefab(piece);
                _PowerButton.SetActive(false);
                _PowerCountDown.SetActive(false);
            }
        }
    }
}