using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class ChatPanel : MonoBehaviour
    {
        [SerializeField]
        private string username;

        [SerializeField]
        private int maxMessages = 25;

        [SerializeField]
        private Text textObjectTemplate;

        [SerializeField]
        private Transform messageParent;

        [SerializeField]
        private InputField chatBox;

        [SerializeField]
        private Color userMessageColor, infoMessageColor;

        private List<Message> messageList = new List<Message>();

        private void Update()
        {
            if (!string.IsNullOrEmpty(chatBox.text))
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SendMessage(($"{username}: {chatBox.text}"), Message.MessageType.User);
                    chatBox.text = string.Empty;
                }
            }
            else
            {
                if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                    chatBox.ActivateInputField();
            }
            if (!chatBox.isFocused)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SendMessage("Hello, welcome to the game\nPress 1 for...\nPress 2 for...\nPress 3 for...", Message.MessageType.Info);
                    Debug.Log("HelpMenu");
                }
            }
        }

        public void SendMessage(string text, Message.MessageType messageType)
        {
            if (messageList.Count >= maxMessages)
            {
                Destroy(messageList[0].TextMessage.gameObject);
                messageList.Remove(messageList[0]);
            }

            var newText = Instantiate(textObjectTemplate, messageParent);

            Message newMessage = new Message(text, newText, messageType);

            newMessage.TextMessage.color = GetMessageColor(messageType);

            messageList.Add(newMessage);
        }

        public Color GetMessageColor(Message.MessageType messageType)
        {
            var color = Color.blue;

            switch (messageType)
            {
                case Message.MessageType.User:
                    color = userMessageColor;
                    break;
                case Message.MessageType.Info:
                    color = infoMessageColor;
                    break;
                default:
                    throw new InvalidOperationException("Не существует цвета для сообщения");
                    break;
            }
            return color;
        }
        [System.Serializable]
        public class Message
        {
            public string Text;
            public Text TextMessage;
            public MessageType Type;

            public Message(string text, Text textMessage, MessageType type)
            {
                Text = text;
                TextMessage = textMessage;
                Type = type;

                TextMessage.text = text;
            }

            public enum MessageType
            {
                User,
                Info
            }
        }

    }
}
