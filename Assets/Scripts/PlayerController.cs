using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using TMPro;
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
    public GameObject timer;
    private TextMeshProUGUI timerTMP;
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
        gamePassed = true;
        _analyticsVariables = FindObjectOfType<AnalyticsVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        gmc.SetScore((int)(transform.position.z - _initalPos));
        if (Input.GetKeyUp("q"))
        {
            TriggerPiecePrefab(player_shape);
            player_shape = GetShape[(ShapeRanking[player_shape]+1)%3];
            TriggerPiecePrefab(player_shape);
        }
        // print(initialTime);
        // print("3224324r");
        // print(timerTMP);
        timerTMP.text = "rotate rightx2,rotate leftx2(360) Time Left : " + (15 - Time.time + _initialTime).ToString("#");

        if ((int)(15 - Time.time + _initialTime) == 0 && gamePassed == false)
        {
            timer.SetActive(false);
            Restart();
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
        if(gmc.GetScore()%200 == 0 && gmc.GetScore() != 0)
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
    }

    private void HealthReducer()
    {
        if (_onUpperCylinder)
        {
            _analyticsVariables.DecrementHealth();  //Decrements by 1
            if (_analyticsVariables.GetHealth() <= 0)
            {
                //Return to lower cylinder
            }
        }
    }

    private void HealthPickup()
    {
        _analyticsVariables.SetHealth(Math.Max(_analyticsVariables.GetHealth()+1, 3));
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
<<<<<<< Updated upstream
            rb.transform.Translate(Vector3.up * 38 );
            rb.transform.Rotate(Vector3.forward, 180);
            cameraObject.transform.Rotate(Vector3.forward, 180);
            cameraObject.transform.Translate(rb.transform.up * 30);
            //Invoke health counter. Calls every X seconds where X = time mentioned in the parameter
            InvokeRepeating("HealthReducer", 7.0f, 7.0f);
            _analyticsVariables.SetHealth(3); //Initialise to 3 lives
        }
        //Remember to cancel the invoke by calling "CancelInvoke();" after returning to lower cylinder

        if (other.gameObject.CompareTag("Health"))
        {
            HealthPickup();
            Destroy(other);
=======
            if (onOuterCylinder)
            {
                onOuterCylinder = false;
                rb.transform.Translate(Vector3.up / 38 );
                rb.transform.Rotate(Vector3.forward, 180);
                cameraObject.transform.Rotate(Vector3.forward, 180);
            }
            else
            {
                onOuterCylinder = true;
                rb.transform.Translate(Vector3.up * 38 );
                rb.transform.Rotate(Vector3.forward, 180);
                cameraObject.transform.Rotate(Vector3.forward, 180);
            }
>>>>>>> Stashed changes
        }
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
