using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsVariables : MonoBehaviour
{
    private int _health = 3;

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
}
