using KBEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelControll : MonoBehaviour {

    public enum PanelType { Info, Login, Match, Room, Chat};

    [Header("Login Panel")]
    public GameObject loginPanel;
    public Text accountText;
    public Text passwdText;
    public Button loginBtn;

    [Header("Match Panel")]
    public GameObject matchPanel;


    [Header("Room Panel")]
    public GameObject roomPanel;
    public Transform[] playerBoxes;

    [Header("Chat Panel")]
    public GameObject chatPanel;
    public Text chatText;
    public InputField chatInput;
    private ScrollRect chatScroll;

    [Header("Info Panel")]
    public GameObject infoPanel;


    private void InitEvent()
    {
        KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");

        KBEngine.Event.registerOut("onAvatarEnterWorld", this, "onAvatarEnterWorld");
        KBEngine.Event.registerOut("onAvatarLeaveWorld", this, "onAvatarLeaveWorld");

        KBEngine.Event.registerOut("readyResult", this, "readyResult");
    }

    public void OnDestroy()
    {
        KBEngine.Event.deregisterOut(this);
    }


    private void ShowTips(Vector2 postion, string tip)
    {
        if (!infoPanel.activeSelf)
        {
            infoPanel.SetActive(true);
        }

        RectTransform Rect = infoPanel.GetComponent<RectTransform>();
        Rect.localPosition = postion;
        Text text = infoPanel.GetComponent<Text>();
        text.text = tip;
    }

    public void OnLoginClick()
    {

        //用户名密码为空
        if (accountText.text == "" || passwdText.text == "")
        {
            ShowTips(new Vector2(10.2f,228), "用户名密码不能为空!");
            return;
        }
        //连接服务器

        KBEngine.Event.fireIn("login", accountText.text, passwdText.text, System.Text.Encoding.UTF8.GetBytes("kbegine_frame_demo"));

    }
    public void onLoginFailed(UInt16 failedcode)
    {
        if (failedcode == 20)
        {
            ShowTips(new Vector2(10.2f, 228), "login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode) + ", " + System.Text.Encoding.ASCII.GetString(KBEngineApp.app.serverdatas()));
        }
        else
        {
            ShowTips(new Vector2(10.2f, 228), "login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode));
        }
    }

    public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, Account accountEntity)
    {
        Debug.Log("accountText.text:" + accountText.text);
        ShowTips(new Vector2(10.2f, 228), "Welcome "+ accountText.text);

        ActivePanel(PanelType.Room);
    }

    private void ClearPlayersGUI()
    {
        foreach (Transform playerBox in playerBoxes)
        {
            playerBox.GetComponent<Image>().enabled = false;
            playerBox.Find("PlayerNameText").GetComponent<Text>().text = "";
        }
    }

    public void UpdatePlayerList()
    {
        ClearPlayersGUI();

        for (int index = 0; index < SpaceData.Instance.SpacePlayers.Count; index++)
        {
            KBEngine.Avatar player = SpaceData.Instance.SpacePlayers[index].owner as KBEngine.Avatar;

            Transform playerBox = playerBoxes[index];

            playerBox.GetComponent<Image>().enabled = true;

            Text playerNameText = playerBox.Find("PlayerNameText").GetComponent<Text>();

            playerNameText.text = player.name.Trim();
        }
    }

    public void OnStarClick()
    {
        KBEngine.Event.fireIn("reqReady", (Byte)1);
    }

    public void readyResult(byte result)
    {
        if(result == 0)
        {
            SceneManager.LoadScene("helloworld");
        }
    }

    public void onAvatarEnterWorld()
    {
        UpdatePlayerList();
    }

    public void onAvatarLeaveWorld()
    {
        UpdatePlayerList();
    }
    private void ActivePanel(PanelType panelType)
    {
        loginPanel.SetActive(panelType == PanelType.Login);
        matchPanel.SetActive(panelType == PanelType.Match);
        roomPanel.SetActive(panelType == PanelType.Room);
        chatPanel.SetActive(panelType == PanelType.Chat);
        
    }

    // Use this for initialization
    void Start ()
    {
        InitEvent();

        ActivePanel(PanelType.Login);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
