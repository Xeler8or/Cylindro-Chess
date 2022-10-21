using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class SendToGoogle : MonoBehaviour
{
    public static SendToGoogle Instance { get; private set; }
    [SerializeField] private string url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScoickLL3WTnSiF_niKaDJEX12n5Li5xnylIxf7P6bs3BbCDg/formResponse";
    private long _sessionID;
    private double _distance;
    private AnalyticsVariables _analyticsVariables;
    
   

    private void Awake() 
    { 
        print("Entered Awake");
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        }
        else
        {
            Instance = this;

        }
    }
    

    private void Start()
    {
        print("Entered Start");
        _analyticsVariables = FindObjectOfType<AnalyticsVariables>();
    }

 

    public void Send() 
    {
        print("Entered Send");
        StartCoroutine(Post(_analyticsVariables));
    }
    
    private IEnumerator Post(AnalyticsVariables analytics)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm(); 
        form.AddField("entry.1259749787", analytics.GetUuid()); 
        form.AddField("entry.849154799", analytics.GetDeathObstacle()); 
        form.AddField("entry.388831527", analytics.GetSpeedAtDeath());
        form.AddField("entry.1026946169",analytics.GetFinalScore());
        form.AddField("entry.908913442", analytics.GetHealthZero());
        form.AddField("entry.1270605244",analytics.GetNotUsedColourPowerUp());
        form.AddField("entry.1789526568",analytics.GetUsedColourPowerUp());
        form.AddField("entry.329301155",analytics.GetCoins().ToString());
        form.AddField("entry.1389378337",analytics.GetUsedCoins());
        form.AddField("entry.1578993175",analytics.GetCounterRainbow());
        form.AddField("entry.1785583492",analytics.GetCounterSlowDown());
        print("Entered Post");
        
        using (UnityWebRequest www = UnityWebRequest.Post(url, form)) 
        {
            print("Yes");
            yield return www.SendWebRequest();
        }
        
    }
}