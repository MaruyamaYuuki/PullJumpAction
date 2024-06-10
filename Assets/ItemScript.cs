using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DestroySelf();
       // Debug.Log("Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}