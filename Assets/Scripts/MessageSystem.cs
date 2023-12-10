using UnityEngine;
using UnityEngine.UI;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] private GameObject messagePrefab;
    [SerializeField] private Transform messageParent;
    [SerializeField] private Button sendButton;
    [SerializeField] private Button receiveButton;
    [SerializeField] private PrivateChatConfig chatConfig;

    private int currentMariaMessageIndex = 0;
    private int currentYouMessageIndex = 0;
    private float xOffset = 200f;
    private void Start()
    {
        sendButton.onClick.AddListener(SendMessage);
        receiveButton.onClick.AddListener(ReceiveMessage);

        receiveButton.gameObject.SetActive(true);
        sendButton.gameObject.SetActive(false);
    }

    private void SendMessage()
    {
        if (currentYouMessageIndex < chatConfig.you.messages.Length)
        {
            Debug.Log($"{chatConfig.you.authorName}: {chatConfig.you.messages[currentYouMessageIndex]}");

            CreateMessagePrefab(chatConfig.you.authorName, chatConfig.you.messages[currentYouMessageIndex]);
            currentYouMessageIndex++;
        }

        receiveButton.gameObject.SetActive(true);
        sendButton.gameObject.SetActive(false);
    }

    private void ReceiveMessage()
    {
        if (currentMariaMessageIndex < chatConfig.maria.messages.Length)
        {
            Debug.Log($"{chatConfig.maria.authorName}: {chatConfig.maria.messages[currentMariaMessageIndex]}");

            CreateMessagePrefab(chatConfig.maria.authorName, chatConfig.maria.messages[currentMariaMessageIndex]);
            currentMariaMessageIndex++;
        }

        sendButton.gameObject.SetActive(true);
        receiveButton.gameObject.SetActive(false);
    }
    private void CreateMessagePrefab(string authorName, string message)
    {
        GameObject newMessageObject = Instantiate(messagePrefab, messageParent);

        TMPro.TextMeshProUGUI messageText = newMessageObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();

        messageText.text = $"<color=red>{authorName}</color>\n<color=blue>{message}</color>";
    }
}