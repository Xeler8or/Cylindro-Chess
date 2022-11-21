using System;
using UnityEngine;

public class AnalyticsVariables : MonoBehaviour
{
    private int health_animation=0;

    private int _health = 3;
    //Set death variable to color, shape, door, lock, arch
    private string _causeOfDeath;
    //Set speed variable on death
    private int _speedAtDeath;
    //Set score on death
    private int _finalScore;
    //Set Platform number where death occurred
    private string _platformNumber;

    //Increase counter for number of times health variable is set to 1
    private int _counterHealthZero = 0;
    //Colour obstacles must have two counters:
    //Counter 1: passed with the same color or dodged
    //Counter 2: passed when the all color power up is set to true
    private int _counterNotUsedColourPowerUp = 0;
    private int _counterUsedColourPowerUp = 0;
    //Counters for number of times a certain power up was purchased
    private int _counterRainbow = 0;
    private int _counterSlowDown = 0;

    private string _uuid;
    private int _coins;
    private int _coinsUsed=0;
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _uuid = UnityEngine.Random.Range(0,100) + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
    }

    public void SetCoins(int coins)
    {
        _coins = coins;
    }

    public int GetCoins()
    {
        return _coins;
    }

    public void UpdateCoins(int d)
    {
        _coins += d;
    }
    
    public int GetUsedCoins()
    {
        return _coinsUsed;
    }

    public void ModifyUsedCoins(int d)
    {
        _coinsUsed += d;
    }
    
    public void ResetUsedCoins()
    {
        _coinsUsed =0;
    }

    public string GetUuid()
    {
        return _uuid;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int h)
    {
        _health = h;
        if(h>0)
        {
            health_animation=1;
            // Debug.Log("HEALTH========================== +1");
        }
        else {
            health_animation=0;
            // Debug.Log("HEALTH========================== 0");
        }
    }

    public void DecrementHealth()
    {
        _health -= 1;
        health_animation=-1;
        // Debug.Log("HEALTH========================== -1");
    }
    
    public int GetAnimatedHealth()
    {
        return health_animation;
    }
    
    public string GetDeathObstacle()
    {
        return _causeOfDeath;
    }

    public void SetDeathObstacle(string obs)
    {
        //print("Entered");
        _causeOfDeath = obs;
        //print("Exited");
    }
    
    public string GetSpeedAtDeath()
    {
        return _speedAtDeath.ToString();
    }

    public void SetSpeedAtDeath(int s)
    {
        _speedAtDeath = s;
    }
    
    public string GetFinalScore()
    {
        return _finalScore.ToString();
    }

    public void SetFinalScore(int s)
    {
        _finalScore = s;
    }
    
    public string GetHealthZero()
    {
        return _counterHealthZero.ToString();
    }

    public void IncrementHealthZero()
    {
        _counterHealthZero+=1;
    }
    
    public void ResetHealthZero()
    {
        _counterHealthZero=0;
    }
    
    public string GetNotUsedColourPowerUp()
    {
        return _counterNotUsedColourPowerUp.ToString();
    }

    public void IncrementNotUsedColourPowerUp()
    {
        _counterNotUsedColourPowerUp+=1;
    }
    public void ResetNotUsedColourPowerUp()
    {
        _counterNotUsedColourPowerUp=0;
    }
    
    public string GetUsedColourPowerUp()
    {
        return _counterUsedColourPowerUp.ToString();
    }

    public void IncrementUsedColourPowerUp()
    {
        _counterUsedColourPowerUp+=1;
    }
    public void ResetUsedColourPowerUp()
    {
        _counterUsedColourPowerUp=0;
    }
    
    public string GetCounterRainbow()
    {
        return _counterRainbow.ToString();
    }

    public void IncrementCounterRainbow()
    {
        _counterRainbow+=1;
    }
    public void ResetCounterRainbow()
    {
        _counterRainbow=0;
    }
    
    public string GetCounterSlowDown()
    {
        return _counterSlowDown.ToString();
    }

    public void IncrementCounterSlowDown()
    {
        _counterSlowDown+=1;
    }
    public void ResetCounterSlowDown()
    {
        _counterSlowDown=0;
    }
    
    public string GetPlatform()
    {
        return _platformNumber;
    }

    public void SetPlatform(string plat)
    {
        _platformNumber=plat;
    }

  
}
