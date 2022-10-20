using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsVariables : MonoBehaviour
{
    private int _health = 3;
    //Set death variable to color, shape, door, lock, arch
    private string _causeOfDeath;
    //Set speed variable on death
    private int _speedAtDeath;
    //Set score on death
    private int _finalScore;

    //Increase counter for number of times health variable is set to 1
    private int _counterHealthOne = 0;
    //Colour obstacles must have two counters:
    //Counter 1: passed with the same color or dodged
    //Counter 2: passed when the all color power up is set to true
    private int _counterNotUsedColourPowerUp = 0;
    private int _counterUsedColourPowerUp = 0;

    private string _uuid;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _uuid = UnityEngine.Random.Range(0,100) + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
    }

    public string GetUuid()
    {
        return _uuid;
    }

    public void SetUuid(string uuid)
    {
        _uuid = uuid;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int h)
    {
        _health = h;
    }

    public void DecrementHealth()
    {
        _health -= 1;
    }
    
    
    public string GetDeathObstacle()
    {
        return _causeOfDeath;
    }

    public void SetDeathObstacle(string obs)
    {
        _causeOfDeath = obs;
    }
    
    public int GetSpeedAtDeath()
    {
        return _speedAtDeath;
    }

    public void SetSpeedAtDeath(int s)
    {
        _speedAtDeath = s;
    }
    
    public int GetFinalScore()
    {
        return _finalScore;
    }

    public void SetFinalScore(int s)
    {
        _finalScore = s;
    }
    
    public int GetHealthOne()
    {
        return _counterHealthOne;
    }

    public void IncrementHealthOne()
    {
        _counterHealthOne+=1;
    }
    
    public int GetNotUsedColourPowerUp()
    {
        return _counterNotUsedColourPowerUp;
    }

    public void IncrementNotUsedColourPowerUp()
    {
        _counterNotUsedColourPowerUp+=1;
    }
    
    public int GetUsedColourPowerUp()
    {
        return _counterUsedColourPowerUp;
    }

    public void IncrementUsedColourPowerUp()
    {
        _counterUsedColourPowerUp+=1;
    }

  
}
