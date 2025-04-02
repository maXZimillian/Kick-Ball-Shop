using TMPro;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popup;
    public GameObject activeButton;
    public TextMeshProUGUI label;

    // Метод для активации popup'а
    public void ShowPopup(string labelText, bool showActiveButton)
    {
        label.text = labelText;
        popup.SetActive(true);
        activeButton.SetActive(showActiveButton);
    }

    // Метод для деактивации popup'а
    public void HidePopup()
    {
        popup.SetActive(false);
    }
}