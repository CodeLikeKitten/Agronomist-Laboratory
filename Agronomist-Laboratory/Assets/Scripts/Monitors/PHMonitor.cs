using TMPro;
using UnityEngine;

public class PHMonitor : MonoBehaviour
{
    public StrawberrySimulator simulator;
    public TMP_Text displayText; // перетащи сюда TextMeshPro объект на мониторе

    void Update()
    {
        if (simulator != null && displayText != null)
        {
            int week = simulator.GetCurrentWeek();
            float ph = simulator.GetPH();

            displayText.text = $"Неделя: {week}\nPH: {ph:F1}";
        }
    }
}
