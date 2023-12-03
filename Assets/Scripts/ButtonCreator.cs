using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private Transform buttonParent;
    [SerializeField] MessageConfig messageConfig;
    [SerializeField] private Transform panel;
    private int messagesCount;
    private float positionCount = 1750f;

    private void Start()
    {
        
    }
    public void CreateButtons()
    {
        Button newButton = Instantiate(buttonPrefab, panel.transform);
        //newButton.transform.localScale = new Vector3(4f, 4f, 2f);

        MessageConfig.Authors randomAuthor = GetAuthor();
        string randomMessage = GetRandomMessage(randomAuthor);

        TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = $"<color=red>{randomAuthor.authorName}</color>\n<color=blue>{randomMessage}</color>";
        
    }

    private MessageConfig.Authors GetAuthor()
    {
        int randomIndex = Random.Range(0, messageConfig.authors.Length);
        return messageConfig.authors[randomIndex];
    }

    private string GetRandomMessage(MessageConfig.Authors author)
    {
        if (author != null && author.messages != null && author.messages.Length > 0)
        {
            // You can implement a random selection logic here
            int randomIndex = Random.Range(0, author.messages.Length);
            return author.messages[randomIndex];
        }

        return string.Empty;
    }
    
}
