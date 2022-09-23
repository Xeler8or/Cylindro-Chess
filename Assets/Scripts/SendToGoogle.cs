using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class SendToGoogle : MonoBehaviour
{
    public static SendToGoogle Instance { get; private set; }
    [SerializeField] private string url;
    public long _userID;
    public long _sessionID;
    public double _distance;
    
    private void Awake() 
    { 
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
    public void Send() 
    {
        // Assign variables
        print("Send");
        _sessionID = (long)Time.time;
        _userID = UnityEngine.Random.Range(1,10);
        StartCoroutine(Post(_sessionID.ToString(), _userID.ToString(), _distance.ToString("N")));
    }
    
    public IEnumerator Post(string sessionID, string userID, string distance)
    {
        print("Post");
        // Create the form and enter responses
        WWWForm form = new WWWForm(); 
        form.AddField("entry.1259749787", userID); 
        form.AddField("entry.849154799", sessionID); 
        form.AddField("entry.388831527", distance);
        
        using (UnityWebRequest www = UnityWebRequest.Post(url, form)) 
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success) {
                print(www.error); }
            else
            {
                print("Form upload complete!");
            } 
        }
    }
}
    



/*
  public void Awake()
    {
        print("Awake");
        
        Send();
    }
public class Survey : MonoBehaviour
{

    [SerializeField] InputField feedback1;

    string URL = "";

    
    public void Send()
    {
        StartCoroutine(Post(feedback1.text));
    }

    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("", s1);




        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        
        yield return www.SendWebRequest();

    }


}
*/

