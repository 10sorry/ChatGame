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

    private void Start()
    {
        sendButton.onClick.AddListener(SendMessage);
        receiveButton.onClick.AddListener(ReceiveMessage);

        // Start with receiving messages, so activate the Receive button.
        receiveButton.gameObject.SetActive(true);
        sendButton.gameObject.SetActive(false);
    }

    private void SendMessage()
    {
        if (currentYouMessageIndex < chatConfig.you.messages.Length)
        {
            // Process the message as needed
            Debug.Log($"{chatConfig.you.authorName}: {chatConfig.you.messages[currentYouMessageIndex]}");

            // Create a message prefab with the current author and message
            CreateMessagePrefab(chatConfig.you.authorName, chatConfig.you.messages[currentYouMessageIndex]);
            currentYouMessageIndex++;
        }

        // After sending a message, activate the Receive button.
        receiveButton.gameObject.SetActive(true);
        sendButton.gameObject.SetActive(false);
    }

    private void ReceiveMessage()
    {
        if (currentMariaMessageIndex < chatConfig.maria.messages.Length)
        {
            // Process the message as needed
            Debug.Log($"{chatConfig.maria.authorName}: {chatConfig.maria.messages[currentMariaMessageIndex]}");

            // Create a message prefab with the current author and message
            CreateMessagePrefab(chatConfig.maria.authorName, chatConfig.maria.messages[currentMariaMessageIndex]);
            currentMariaMessageIndex++;
        }

        // After receiving a message, activate the Send button.
        sendButton.gameObject.SetActive(true);
        receiveButton.gameObject.SetActive(false);
    }

    private void CreateMessagePrefab(string authorName, string message)
    {
        // Instantiate the message prefab
        GameObject newMessageObject = Instantiate(messagePrefab, messageParent);

        // Get the TextMeshProUGUI component from the message object
        TMPro.TextMeshProUGUI messageText = newMessageObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();

        // Set the text content using the provided author and message
        messageText.text = $"<color=red>{authorName}</color>\n<color=blue>{message}</color>";
    }
}