using UnityEngine;

public class Valve : MonoBehaviour, IClickable
{
    public StrawberrySimulator simulator;
    public float changeSpeed = 0.5f;
    public bool isIncrease = true;
    private bool isActive = false;

    public void OnClick()
    {
        isActive = !isActive; // переключение работы вентиля
    }

    void Update()
    {
        if (isActive && simulator != null)
        {
            float delta = changeSpeed * Time.deltaTime;
            if (!isIncrease) delta = -delta;
            simulator.AdjustPH(delta);
        }
    }
}
