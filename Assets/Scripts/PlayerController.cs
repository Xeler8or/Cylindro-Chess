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
    public Constants.Shapes player_shape;
    [SerializeField]
    private GameObject restartPanel;
    private GameController gmc;
    [SerializeField]
    private float _initalPos = 0;
    [SerializeField]
    private Constants.Color color;
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

    }

    // Update is called once per frame
    void Update()
    {
        //gmc.SetScore((int)(transform.position.z - _initalPos));
        if (Input.GetKeyUp("q"))
        {
            TriggerPiecePrefab(player_shape);
            player_shape = GetShape[(ShapeRanking[player_shape]+1)%3];
            TriggerPiecePrefab(player_shape);
            print(player_shape);

        }
    }

    private void TriggerPiecePrefab(Constants.Shapes player_shape)
    {
        bool currState = gameObject.transform.GetChild(ShapeRanking[player_shape]).gameObject.activeSelf;
        gameObject.transform.GetChild(ShapeRanking[player_shape]).gameObject.SetActive(!currState);
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
