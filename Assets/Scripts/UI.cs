using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public GameObject seeMore;
    public GameObject extraInfo;
    public GameObject extraInfoHead;
    public GameObject extraInfoBody;
    public GameObject extraInfoFoot;
    public GameObject pauseMenu;

    public bool inExtraInfo = false;
    public bool inPauseMenu = false;

    // Start is called before the first frame update
    public void Start() {
        seeMore = GameObject.FindGameObjectWithTag("seeMore");
        extraInfo = GameObject.FindGameObjectWithTag("extraInfo");
        extraInfoHead = GameObject.FindGameObjectWithTag("infoHead");
        extraInfoBody = GameObject.FindGameObjectWithTag("infoBody");
        extraInfoFoot = GameObject.FindGameObjectWithTag("infoFoot");
        pauseMenu = GameObject.FindGameObjectWithTag("pauseMenu");
    }

    // Update is called once per frame
    public void Update()
    {
        showUsePrompt(plr.canInteract);
    }

    public void showUsePrompt(bool visible) {
        if(visible) {
            seeMore.transform.localPosition = new Vector3(0, -260, 0);
        } else {
            seeMore.transform.localPosition = new Vector3(0, -320, 0);
        }
    }

    public void setUIOpen(GameObject element, bool openState) {
        if(element == extraInfo) {
            extraInfoHead.GetComponent<Text>().text = plr.lookingAt.GetComponent<exhibit>().head;
            extraInfoBody.GetComponent<Text>().text = plr.lookingAt.GetComponent<exhibit>().body;
            extraInfoFoot.GetComponent<Text>().text = plr.lookingAt.GetComponent<exhibit>().foot;
            extraInfo.GetComponentInChildren<RawImage>().texture = plr.lookingAt.GetComponent<exhibit>().pic;
        }

        if(openState) {
            element.transform.localPosition = new Vector3(-800, -450, 0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            plr.canMove = false;
            plr.canInteract = false;
            inExtraInfo = true;
        } else {
            element.transform.localPosition = new Vector3(-800, 450, 0);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            plr.canMove = true;
            plr.canInteract = true;
            inExtraInfo = false;
        }
    }
}