using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    
    [SerializeField] private ButtonCreator buttonCreator;
    [SerializeField] private MessageConfig messageConfig;
    private TextMeshProUGUI messageText;

    /*private void Start()
    {
        Button[] buttons = buttonCreator.GetButtons();
        foreach (Button button in buttons)
        {
            TextMeshProUGUI messageText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (messageConfig != null)
            {
                messageText.text = $"Author";
            }
        }

    }
    */

    
    
}
