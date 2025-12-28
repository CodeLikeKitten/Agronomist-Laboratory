using TMPro;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public TMP_Text displayText; // сюда перетащи TextMeshPro объект

    public void UpdateText(string text)
    {
        if (displayText != null)
            displayText.text = text;
    }
}
