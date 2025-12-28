using UnityEngine;

public class LampSwitch : MonoBehaviour, IClickable
{
    public StrawberrySimulator simulator;

    public void OnClick()
    {
        if (simulator != null)
            simulator.TurnOnLamp();
    }
}
