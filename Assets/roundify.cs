using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundify : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3((transform.localScale.x * (1/transform.parent.GetComponent<Transform>().localScale.x)), transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
