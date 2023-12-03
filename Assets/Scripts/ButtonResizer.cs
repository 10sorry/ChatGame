using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonResizer : MonoBehaviour
{
    [SerializeField] private Button myButton;
    [SerializeField] private TextMeshProUGUI buttonText;

    private void Start()
    {
        // Пример установки размера текста в коде
        buttonText.fontSize = 24f;

        // Пример установки размера кнопки в зависимости от размера текста
        ResizeButton();
    }

    private void ResizeButton()
    {
        // Получите предпочтительные размеры контента
        RectTransform contentRect = buttonText.rectTransform;
        Vector2 preferredSize = new Vector2(LayoutUtility.GetPreferredWidth(contentRect), LayoutUtility.GetPreferredHeight(contentRect));

        // Установите размеры кнопки
        RectTransform buttonRect = myButton.GetComponent<RectTransform>();
        buttonRect.sizeDelta = preferredSize;
    }
}