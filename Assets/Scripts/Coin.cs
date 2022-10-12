using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 90f;
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Destroy this coin object
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed* Time.deltaTime);
    }
}
