using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalGravity : MonoBehaviour
{
    public List<GameObject> objects;
 
    public float gravitationalPull = 9.8f;
 
    void FixedUpdate() {
        
        //or apply gravity to all game objects with rigidbody
        foreach (GameObject o in UnityEngine.Object.FindObjectsOfType<GameObject>()) {
            if(o.GetComponent<Rigidbody>() && o != gameObject){
                o.GetComponent<Rigidbody>().AddForce((gameObject.transform.position - o.transform.position).normalized * gravitationalPull);
            }
        }
    }
}
