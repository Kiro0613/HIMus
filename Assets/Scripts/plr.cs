using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plr : MonoBehaviour {
    private GameObject player;
    private Camera cam;
    private GameObject lookingAt;

    private GameObject seeMore;
    private GameObject extraInfo;
    private GameObject extraInfoHead;
    private GameObject extraInfoBody;
    private GameObject extraInfoFoot;
    private GameObject pauseMenu;

    private bool canInteract = false;
    public static bool canMove = true;
    private bool inExtraInfo = false;
    private bool inPauseMenu = false;

    private void Awake() {
        seeMore = GameObject.FindGameObjectWithTag("seeMore");
        extraInfo = GameObject.FindGameObjectWithTag("extraInfo");
        extraInfoHead = GameObject.FindGameObjectWithTag("infoHead");
        extraInfoBody = GameObject.FindGameObjectWithTag("infoBody");
        extraInfoFoot = GameObject.FindGameObjectWithTag("infoFoot");
        pauseMenu = GameObject.FindGameObjectWithTag("pauseMenu");
    }

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        seeMore.SetActive(false);
        extraInfo.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.E)){
            if(lookingAt.tag == "display" && canInteract) {
                openArtifactInfo();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(inExtraInfo) {
                closeArtifactInfo();
            } else if(inPauseMenu) {
                closePauseMenu();
            } else {
                openPauseMenu();
            }
        }
    }

    void FixedUpdate() {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, 5)) {
            lookingAt = hitInfo.collider.gameObject;
            if(lookingAt.tag == "display") {
                canInteract = true;
                seeMore.SetActive(true);
            }
        } else {
            canInteract = false;
            seeMore.SetActive(false);
        }
    }

    void openArtifactInfo() {
        Text[] infoBoxes = extraInfo.GetComponentsInChildren<Text>();
        extraInfoHead.GetComponent<Text>().text = lookingAt.GetComponent<exhibit_text>().head;
        extraInfoBody.GetComponent<Text>().text = lookingAt.GetComponent<exhibit_text>().body;
        extraInfoFoot.GetComponent<Text>().text = lookingAt.GetComponent<exhibit_text>().foot;
        extraInfo.GetComponentInChildren<RawImage>().texture = lookingAt.GetComponent<exhibit_text>().pic;

        extraInfo.SetActive(true);
        canMove = false;
        inExtraInfo = true;
    }

    void closeArtifactInfo() {
        extraInfo.SetActive(false);
        canMove = true;
        inExtraInfo = false;
    }

    void openPauseMenu() {
        pauseMenu.SetActive(true);
        canMove = false;
        inPauseMenu = true;
    }

    void closePauseMenu() {
        pauseMenu.SetActive(false);
        canMove = true;
        inPauseMenu = false;
    }
}
