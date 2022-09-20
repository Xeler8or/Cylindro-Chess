using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
   
    string scene = "SampleScene";
    public GameObject restartScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("Collide");
        if (coll.gameObject.tag == "Player"){
            Time.timeScale = 0;
            restartScreen.SetActive(true);
            
        }
    }

    public void replay(){
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
  
    
}
