using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plr : MonoBehaviour
{
    public GameObject player;
	public Text tooltip;
    public Image bg;
    public GameObject floor1btn;
    public GameObject floor2btn;
    public static string nearButton = null;
    private Vector3 currentFloor;
    private Vector3 newFloor;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && plr.nearButton != null)
        {
            if (nearButton == "floor1btn")
            {
                currentFloor = floor1btn.transform.position;
                newFloor = floor2btn.transform.position;
            }
            else
            {
                currentFloor = floor2btn.transform.position;
                newFloor = floor1btn.transform.position;
            }

            elevDoor.doorClosed = true;
            Invoke("open", elevDoor.doorDelay);
            Invoke("movePlr", elevDoor.doorDelay/2);
        }
    }
	
	private void OnTriggerEnter(Collider item){
        
	}
	
	private void OnTriggerExit(){
		tooltip.text = "";
        bg.gameObject.SetActive(false);
        nearButton = null;
    }

    void open()
    {
        elevDoor.doorClosed = false;
    }

    void movePlr()
    {
        player.transform.position += (newFloor - currentFloor);
    }
}
