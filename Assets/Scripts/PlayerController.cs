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

    public Material redMat;
    public Material blueMat;
    public Material greenMat;
    public Material yellowMat;
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
            Constants.Color c = GetNextColor(color);
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
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            if (other.gameObject.GetComponent<ObstacleController>().color != color)
            {
                Debug.Log("Color diff");
                Restart();
            }
        }
    }
}
