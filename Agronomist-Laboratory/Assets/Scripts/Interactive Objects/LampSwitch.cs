using UnityEngine;

public class LampSwitch : MonoBehaviour, IClickable
{
    [Header("Scene lamps")]
    public Light[] lamps;

    [Header("Simulator")]
    public StrawberrySimulator simulator;

    private bool isOn = false;

    void Start()
    {
        // На старте ВСЕ лампы выключены
        SetLamps(false);
    }

    public void OnClick()
    {
        isOn = !isOn;
        SetLamps(isOn);

        if (simulator != null)
            simulator.lampIntensity = isOn ? 1f : 0f;
    }

    void SetLamps(bool state)
    {
        foreach (var lamp in lamps)
        {
            if (lamp != null)
                lamp.enabled = state;
        }
    }
}
