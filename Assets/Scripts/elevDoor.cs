using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevDoor : MonoBehaviour
{
    public GameObject elevator;
    private GameObject doorL;
    private GameObject doorR;

    public static bool doorClosed = false;

    private float closedPos = 1.005f;
    private float openPos = 2.96f;

    private float targX;
    private float scale;

    public float speed;
    public static int doorDelay = 4;

    // Start is called before the first frame update
    void Start()
    {
        doorL = elevator.transform.Find("door/door L").gameObject;
        doorR = elevator.transform.Find("door/door R").gameObject;

        targX = elevator.transform.position.x;

        scale = elevator.transform.localScale.x;
        closedPos *= scale;
        openPos *= scale;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        

        if (doorClosed)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, new Vector3(targX + closedPos, doorL.transform.position.y, doorL.transform.position.z), step);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, new Vector3(targX + closedPos * -1, doorL.transform.position.y, doorL.transform.position.z), step);
        }
        else
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, new Vector3(targX + openPos, doorL.transform.position.y, doorL.transform.position.z), step);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, new Vector3(targX + openPos * -1, doorL.transform.position.y, doorL.transform.position.z), step);
        }
    }

    
}
