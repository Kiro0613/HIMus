using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plr : MonoBehaviour {
    private GameObject player;
    private Camera cam;
    public static GameObject lookingAt;
    
    public static UI ui;

    public static bool canInteract = false;
    public static bool canMove = true;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKey(KeyCode.E)){
            if(lookingAt.tag == "display" && canInteract) {
                ui.setUIOpen(lookingAt, true);
            }
        }
    }

    void FixedUpdate() {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, 7) && !ui.inExtraInfo && !ui.inPauseMenu) {
            lookingAt = hitInfo.collider.gameObject;
            if(lookingAt.tag == "display") {
                canInteract = true;
            }
        } else {
            canInteract = false;
        }
    }
}
