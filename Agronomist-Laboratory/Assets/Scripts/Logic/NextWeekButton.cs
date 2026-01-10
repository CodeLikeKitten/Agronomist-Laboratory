using UnityEngine;

public class SkipWeekButton : MonoBehaviour, IClickable
{
    public StrawberrySimulator simulator;

    public void OnClick()
    {
        if (simulator == null)
        {
            Debug.LogWarning("SkipWeekButton: Simulator не назначен");
            return;
        }

        simulator.SkipWeek();
        Debug.Log("Нажата кнопка: пропустить неделю");
    }
}
