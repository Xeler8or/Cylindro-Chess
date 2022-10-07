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
    public Collider _lock;
    public Material redMat;
    public Material blueMat;
    public Material greenMat;
    public Material yellowMat;
    public GameObject timer;
    private TextMeshProUGUI timerTMP;
    public bool triggered=false;
    public bool gamePassed=false;
    public bool posStick = false;

    private float initialTime;
    // Start is called before the first frame update
    public Dictionary<Constants.Shapes, int> ShapeRanking = new Dictionary<Constants.Shapes, int>{
        {Constants.Shapes.Cube,0},
        {Constants.Shapes.Sphere,1},
        {Constants.Shapes.Cone,2}
    };
    public Dictionary<int,Constants.Shapes> GetShape = new Dictionary<int,Constants.Shapes>{
        {0,Constants.Shapes.Cube},
        {1,Constants.Shapes.Sphere},
        {2,Constants.Shapes.Cone}
    };

    void Start()
    {
        Velocity = 10f;
        rb.inertiaTensor = _inertiaTensor;
        gmc = FindObjectOfType<GameController>();
        player_shape = Constants.Shapes.Cube;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        ChangeMaterial(gameObject.transform.GetChild(0).gameObject);
        timerTMP = timer.GetComponent<TextMeshProUGUI>();
        print(timerTMP);
        posStick = false;
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
        timerTMP.text = "Time Left : " + (100 - Time.time + initialTime).ToString("#.#");

        if ((int)(120 - Time.time + initialTime) == 0 && !gamePassed)
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
        if(gmc.GetScore()%200 == 0 && gmc.GetScore() != 0)
        {
            Velocity += 5f;
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

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<ObstacleController>().color != color)
            {
                Restart();
            }
        }
        
        if (other.gameObject.CompareTag("zone") && !triggered)
        {
            // other.gameObject.transform.eulerAngles = new Vector3(-180, 0, 0);
            // posStick = true;
            _lock = other;
            print("Hello");
            oldVelocity = Velocity;
            print("Look here");
            print(oldVelocity);
            Velocity = 0f;
            LeftRight.rotateFlag = false;
            initialTime = Time.time;
            timer.SetActive(true);
            triggered = true;
            gamePassed = false;
        }
    }

    public void ContinuePlay()
    {
        posStick = false;
        Destroy(_lock.gameObject);
        print("=========>");
        print(oldVelocity);
        Velocity = ((int)(gmc.GetScore() / 200))*5 + 10;
        LeftRight.rotateFlag = true;
        timer.SetActive(false);
        triggered = false;
        gamePassed = true;
    }
    
}
