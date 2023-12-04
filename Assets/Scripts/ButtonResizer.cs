using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonResizer : MonoBehaviour
{
    [SerializeField] private Button myButton;
    [SerializeField] private TextMeshProUGUI buttonText;

    private void Start()
    {
        buttonText.fontSize = 24f;
        
        ResizeButton();
    }

    private void ResizeButton()
    {
        RectTransform contentRect = buttonText.rectTransform;
        Vector2 preferredSize = new Vector2(LayoutUtility.GetPreferredWidth(contentRect), LayoutUtility.GetPreferredHeight(contentRect));
        
        RectTransform buttonRect = myButton.GetComponent<RectTransform>();
        buttonRect.sizeDelta = preferredSize;
    }
}