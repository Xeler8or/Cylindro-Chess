using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private readonly Vector3 _inertiaTensor = new Vector3(0f,0f,0f);
    public static float Velocity;
    private float oldVelocity = 0f;
    public Constants.Shapes player_shape;
    [SerializeField]
    private GameObject restartPanel;
    private GameController gmc;
    [SerializeField]
    private float _initalPos = 0;
    [SerializeField]
    private Constants.Color color;
    
    public Material redMat;
    public Material blueMat;
    public Material greenMat;
    public Material yellowMat;
    public Material rainbowMat;
    public GameObject timer;
    private TextMeshProUGUI timerTMP;
    public GameObject powerTimer;
    private TextMeshProUGUI powerTimerTMP;
    // public bool triggered=false;
    public bool gamePassed=true;
    // public bool posStick = false;
    // private LeftRight leftrightHandle;
    public bool platformRotate = true;
    public GameObject lockRotator;
    public GameObject cameraObject;
    private float _initialTime;
    private bool _onUpperCylinder;
    private AnalyticsVariables _analyticsVariables;
    public static bool onOuterCylinder = false;
    public PauseGame pauseGame;

    public bool RainbowActive = false;
    public float RainbowStartTime;
    // Start is called before the first frame update
    public Dictionary<Constants.Shapes, int> ShapeRanking = new Dictionary<Constants.Shapes, int>{
        {Constants.Shapes.Cube,0},
        {Constants.Shapes.Sphere,1},
        {Constants.Shapes.Cone,2}
    };

    public Dictionary<int, Constants.Shapes> GetShape = new Dictionary<int, Constants.Shapes>
    {
        { 0, Constants.Shapes.Cube },
        { 1, Constants.Shapes.Sphere },
        { 2, Constants.Shapes.Cone }
    };

    void Start()
    {
        Velocity = Constants.INITIAL_PLAYER_SPEED;
        rb.inertiaTensor = _inertiaTensor;
        gmc = FindObjectOfType<GameController>();
        player_shape = Constants.Shapes.Cube;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        ChangeMaterial(gameObject.transform.GetChild(0).gameObject);
        timerTMP = timer.GetComponent<TextMeshProUGUI>();
        powerTimerTMP = powerTimer.GetComponent<TextMeshProUGUI>();
        gamePassed = true;
        _analyticsVariables = FindObjectOfType<AnalyticsVariables>();
        pauseGame = FindObjectOfType<PauseGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RainbowActive){
            ManageRainbowPower();
        }

        if ((int)(gmc.GetScore() - (transform.position.z - _initalPos)) == 20)
        {
            Restart();
        }
        gmc.SetScore((int)Math.Max(gmc.GetScore(), transform.position.z - _initalPos));
        if (Input.GetKeyUp("q"))
        {
            TriggerPiecePrefab(player_shape);
            player_shape = GetShape[(ShapeRanking[player_shape]+1)%3];
            TriggerPiecePrefab(player_shape);
        }
        
        timerTMP.text = "Time Left : " + (15 - Time.time + _initialTime).ToString("#");

        if ((int)(15 - Time.time + _initialTime) == 0 && gamePassed == false)
        {
            timer.SetActive(false);
            _analyticsVariables.SetDeathObstacle("Lock");
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame.pauseGame();
        }
    }

    private void TriggerPiecePrefab(Constants.Shapes player_shape)
    {
        bool currState = gameObject.transform.GetChild(ShapeRanking[player_shape]).gameObject.activeSelf;
        GameObject child  = gameObject.transform.GetChild(ShapeRanking[player_shape]).gameObject;
        child.SetActive(!currState);
        ChangeMaterial(child);
    }
    
    private void Restart()
    {
        RainbowActive = false;
        _analyticsVariables.SetSpeedAtDeath((int)Velocity);
        _analyticsVariables.SetFinalScore(gmc.GetScore());
        print("Restart");
        print(_analyticsVariables._causeOfDeath);
        print(_analyticsVariables._speedAtDeath);
        print(_analyticsVariables._finalScore);
        Time.timeScale = 0;
        restartPanel.SetActive(true);
        //SendToGoogle.Instance.Send();
        Destroy(gameObject);
    }

    private Constants.Color GetNextColor(Constants.Color color)
    {
        switch (color)
        {
            case Constants.Color.Red:
                return Constants.Color.Blue;
            case Constants.Color.Blue:
                return Constants.Color.Green;
            case Constants.Color.Green:
                return Constants.Color.Yellow;
            case Constants.Color.Yellow:
                return Constants.Color.Red;
            default:
                return Constants.Color.Red;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0,0,Velocity);
        if (gmc.GetScore() % 100 == 0 && gmc.GetScore() != 0)
        {
            Velocity += 1f;
        }
        if(gmc.GetScore()%200 == 0 && gmc.GetScore() != 0 && RainbowActive == false)
        {
            Constants.Color c = GetNextColor(color);
            color = c;
            GameObject child = gameObject.transform.GetChild(ShapeRanking[player_shape]).gameObject;
            ChangeMaterial(child);
        }
    }

    private void ChangeMaterial(GameObject gm)
    {
        if(color == Constants.Color.Red)
            gm.GetComponent<MeshRenderer>().material = redMat;
        else if(color == Constants.Color.Blue)
            gm.GetComponent<MeshRenderer>().material = blueMat;
        else if(color == Constants.Color.Green)
            gm.GetComponent<MeshRenderer>().material = greenMat;
        else if(color == Constants.Color.Yellow)
            gm.GetComponent<MeshRenderer>().material = yellowMat;
        else if(color == Constants.Color.Rainbow)
            gm.GetComponent<MeshRenderer>().material = rainbowMat;
    }

    private void HealthReducer()
    {
        _analyticsVariables.DecrementHealth();  //Decrements by 1
        if (_analyticsVariables.GetHealth() <= 0)
        {
            _analyticsVariables.SetHealth(0);
            CancelInvoke();
            MoveToInner();//Return to lower cylinder
        }
    }
    
    private void MoveToInner()
    {
        onOuterCylinder = false;
        rb.transform.Translate(Vector3.down + (new Vector3(0, 40f, 0)) );
        rb.transform.Rotate(Vector3.forward, 180);
        cameraObject.transform.Rotate(Vector3.forward, 180);
    }
    
    private void MoveToOuter()
    {
        onOuterCylinder = true;
        rb.transform.Translate(Vector3.up + (new Vector3(0,38f, 0) ) );
        rb.transform.Rotate(Vector3.forward, 180);
        cameraObject.transform.Rotate(Vector3.forward, 180);
    }

    private void HealthPickup()
    {
        _analyticsVariables.SetHealth(Math.Min(_analyticsVariables.GetHealth()+1, 3));
    }

    private void HandleBuying(int cost, Collider other)
    {
        if (_analyticsVariables.GetCoins() >= cost)
        {
            _analyticsVariables.UpdateCoins(-cost);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyColor")||other.gameObject.CompareTag("Enemy_Shape")||other.gameObject.CompareTag("Enemy_Door")||other.gameObject.CompareTag("Enemy_Black"))
        {
            if (RainbowActive){
                return;
            }
            if (other.gameObject.GetComponent<ObstacleController>().color != color)
            {
                _analyticsVariables.SetDeathObstacle(other.gameObject.tag);
                Restart();
            }
        }
        if (other.gameObject.CompareTag("zone"))
        {
            Instantiate(lockRotator,
                new Vector3(transform.position.x, transform.position.y-5f, transform.position.z + 20f), Quaternion.Euler(new Vector3(-90f,0f,0f)));
            oldVelocity = Velocity;
            Velocity = 0f;
            platformRotate = false;
            _initialTime = Time.time;
            timer.SetActive(true);
            // triggered = true;
            gamePassed = false;
        }

        if (other.gameObject.CompareTag("Portal"))
        {
            if (onOuterCylinder)
            {
                CancelInvoke();
                MoveToInner();
            }
            else
            {
                //Invoke health counter. Calls every X seconds where X = time mentioned in the parameter
                InvokeRepeating("HealthReducer", Constants.HEALTH_TIMER, Constants.HEALTH_TIMER);
                MoveToOuter();
            }
        }
        //Remember to cancel the invoke by calling "CancelInvoke();" after returning to lower cylinder
        if (other.gameObject.CompareTag("Health"))
        {
            HealthPickup();
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.CompareTag("Rainbow"))
        {
            StartRainbowPower();
            HandleBuying(2, other);
        }

        if (other.gameObject.CompareTag("TutorialTrigger"))
        {
            GameTutorial.showTutorial();
        }

        if (other.gameObject.CompareTag("SlowDownPowerUp"))
        {
            Velocity -= 5;
            HandleBuying(2, other);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            _analyticsVariables.UpdateCoins(1);
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Bounce"))
        {
            Velocity = -Velocity;
        }
        print(Velocity);
    }

    public void StartRainbowPower(){
        //Debug.Log("Power Active");
        
        RainbowActive = true;
        RainbowStartTime = Time.time;
        GameObject child = gameObject.transform.GetChild(ShapeRanking[player_shape]).gameObject;
        child.GetComponent<MeshRenderer>().material = rainbowMat;   
        color = Constants.Color.Rainbow;
        powerTimer.SetActive(true);
    }
    public void ManageRainbowPower(){
        //Debug.Log(Time.time - RainbowStartTime);
        if (Time.time - RainbowStartTime > 15){
            powerTimerTMP.text = (20 - Time.time + RainbowStartTime).ToString("#.#");
        }
        if (Time.time - RainbowStartTime > 20){
            EndRainbowPower();
        }
    }
    public void EndRainbowPower(){
        //Debug.Log("Power finished");
        powerTimer.SetActive(false);
        RainbowActive = false;
        GameObject child = gameObject.transform.GetChild(ShapeRanking[player_shape]).gameObject;
        child.GetComponent<MeshRenderer>().material = redMat;
        color = Constants.Color.Red;
    }
    public void ContinuePlay()
    {
        // posStick = false;
        Velocity = oldVelocity;
        platformRotate = true;
        timer.SetActive(false);
        // triggered = false;
        gamePassed = true;
    }
    
}
