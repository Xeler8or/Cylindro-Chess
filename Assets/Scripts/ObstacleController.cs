using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Constants.Pieaces piece;
    public Constants.Color color;
    public Material whiteMat;
    public Material blackMat;
    private GameController _gameController;
    private MeshRenderer _renderer;
    

    private void SetMaterial()
    {
        if(color.whi)
    }

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (_gameController.GetisKing())
        {
            SetMaterial();
        }
    }
}