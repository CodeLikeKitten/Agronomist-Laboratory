using UnityEngine;
using static UnityEngine.InputSystem.HID.HID;

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
        simulator.lampIntensity = 0;
        updateLamps();
    }

    public void OnClick()
    {
        isOn = !isOn;
        if (simulator != null)
            simulator.lampIntensity = isOn ? 1f : 0f;
    }

    void updateLamps()
    {
        foreach (var lamp in lamps)
        {
            if (lamp != null)
            {
                lamp.enabled = isOn;
                lamp.intensity = 100f * simulator.lampIntensity;
            }
        }
    }

    void Update()
    {
        isOn = simulator.lampIntensity > 0f;
        updateLamps();
}
}
