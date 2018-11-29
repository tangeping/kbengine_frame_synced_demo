using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

    [Header("Chat Panel")]
    public GameObject chatPanel;
    public Text chatText;
    public InputField chatInput;
    private ScrollRect chatScroll;

    // Use this for initialization
    void Start () {
        this.chatScroll = this.chatPanel.transform.Find("ChatScroll").GetComponent<ScrollRect>();
    }
    public void ChatToggle()
    {
        chatPanel.SetActive(!chatPanel.activeSelf);

        if (chatPanel.activeSelf)
        {
            this.chatInput.ActivateInputField();
            this.chatScroll.normalizedPosition = new Vector2(0, 0);
        }
    }

    public void ChatMessage(string playerName, string text, int spawnIndex)
    {
        if (spawnIndex < 0)
        {
            spawnIndex = 0;
        }
        this.chatText.text += string.Format("{0}: {1}\n", playerName, text);
        this.chatScroll.normalizedPosition = new Vector2(0, 0);
    }

    public void ChatSend()
    {
        string text = this.chatInput.text;
        if (text != "")
        {
            this.chatInput.text = "";
            ChatMessage("typ", text, 1);

            this.chatInput.ActivateInputField();
        }
    }
    // Update is called once per frame
    void Update () {

        if (chatPanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            ChatSend();
        }
    }
}
