using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeline : MonoBehaviour
{
    private bool isColliding = false;
    private GameObject collidingWith = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        isColliding = true;
        collidingWith = other.gameObject;
    }

    private void OnTriggerExit(Collider other) {
        isColliding = false;
        collidingWith = null;
    }
}
