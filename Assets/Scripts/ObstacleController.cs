using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour

{
    
    public GameObject restartPanel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Gravity on Obstacles
        //rb.AddForce(new Vector3(-transform.position.x, -transform.position.y, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("JJJJJJJJJJJJJJ");

            Destroy(this.gameObject);
            //Restart
            Time.timeScale = 0;
            GameObject go;
            go = Instantiate(restartPanel) as GameObject;
            restartPanel.SetActive(true);
            //Call Analytics
        }
    }
}
