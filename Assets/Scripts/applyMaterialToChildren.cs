using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyMaterialToChildren : MonoBehaviour
{
    public Material texture;
    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;
        
        for(int i = 0; i < children; i++)
        {
            transform.GetChild(i).GetChild(0).gameObject.GetComponent<Renderer>().material = texture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
