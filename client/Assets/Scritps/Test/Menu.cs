using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour {


    [Header("Match Panel")]
    public GameObject matchPanel;


    [Header("Multiplayer Panel")]
    public GameObject multiplayerPanel;

    public GameObject chatPanel;
    public Text chatText;
    public InputField chatInput;
    private ScrollRect chatScroll;


    // Use this for initialization
    void Start () {
        this.chatScroll = this.chatPanel.transform.Find("ChatScroll").GetComponent<ScrollRect>();
    }
	
	// Update is called once per frame
	void Update () {
//         if (chatPanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
//         {
//             ChatSend();
//         }

        Debug.Log(System.DateTime.Now + "." + System.DateTime.Now.Millisecond);
    }



    public void EnableMatchPanel()
    {
        this.matchPanel.SetActive(!matchPanel.activeSelf);
    }


    public void EnableChat()
    {
        //multiplayerPanel.SetActive(!multiplayerPanel.activeSelf);
        chatPanel.SetActive(!chatPanel.activeSelf);
    }


    public void ChatReceived(string playerName, string text)
    {
        this.chatText.text += string.Format("{0}: {1}\n", playerName, text);
        //this.chatScroll.normalizedPosition = new Vector2(0, 0);
    }

    public void ChatSend()
    {
        string text = this.chatInput.text;
        if (text != "")
        {
            this.chatInput.text = "";

            ChatReceived("type", text);
            this.chatInput.ActivateInputField();
        }
    }

}
