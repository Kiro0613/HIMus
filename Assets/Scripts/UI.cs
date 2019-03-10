﻿using System.Collections;
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
        if(plr.canInteract) {
            showUsePrompt(true);
        } else {
            showUsePrompt(false);
        }
    }

    void lockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void unlockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void showUsePrompt(bool visible) {
        if(visible) {
            seeMore.transform.localPosition = new Vector3(0, -260, 0);
        } else {
            seeMore.transform.localPosition = new Vector3(0, -320, 0);
        }
    }

    public void openArtifactInfo() {
        Text[] infoBoxes = extraInfo.GetComponentsInChildren<Text>();
        extraInfoHead.GetComponent<Text>().text = plr.lookingAt.GetComponent<exhibit_text>().head;
        extraInfoBody.GetComponent<Text>().text = plr.lookingAt.GetComponent<exhibit_text>().body;
        extraInfoFoot.GetComponent<Text>().text = plr.lookingAt.GetComponent<exhibit_text>().foot;
        extraInfo.GetComponentInChildren<RawImage>().texture = plr.lookingAt.GetComponent<exhibit_text>().pic;

        extraInfo.transform.localPosition = new Vector3(-800, -450, 0);
        unlockCursor();
        plr.canMove = false;
        plr.canInteract = false;
        inExtraInfo = true;
    }

    public void closeArtifactInfo() {
        extraInfo.transform.localPosition = new Vector3(-800, 450, 0);
        lockCursor();
        plr.canMove = true;
        plr.canInteract = true;
        inExtraInfo = false;
    }

    public void openPauseMenu() {
        pauseMenu.transform.localPosition = new Vector3(-800, -450, 0);
        unlockCursor();
        plr.canMove = false;
        plr.canInteract = false;
        inPauseMenu = true;
    }

    public void closePauseMenu() {
        pauseMenu.transform.localPosition = new Vector3(-800, 450, 0);
        lockCursor();
        plr.canMove = true;
        plr.canInteract = true;
        inPauseMenu = false;
    }
}