using System.Collections.Generic;
using UnityEngine;

public class StrawberrySimulator : MonoBehaviour
{
    [Header("Сimulation Settings")]
    public int totalWeeks = 3;
    public float pH = 6f;
    public float lampIntensity = 0f; // 0 = выключена, 1 = включена
    public float pHDeviationMin = -1.5f;
    public float pHDeviationMax = 1.5f;

    [Header("Plants")]
    public List<Strawberry> strawberries = new List<Strawberry>();

    [Header("Scene Objects")]
    public Transform bushesParent; // родитель всех кустов на сцене

    private int currentWeek = 1;

    void Start()
    {
        InitializeSimulation();
    }

    void InitializeSimulation()
    {
        currentWeek = 1;
        lampIntensity = 0f;
        pH += Random.Range(pHDeviationMin, pHDeviationMax);

        // Автоматически подтягиваем все кусты из сцены
        strawberries.Clear();
        foreach(Transform bush in bushesParent)
{
            Strawberry berry = new Strawberry();
            berry.name = bush.name;
            berry.visual = bush.gameObject;
            berry.size = 0.2f;
            berry.finalSize = (Random.value < 0.5f) ? StrawberrySize.Medium : StrawberrySize.Large;
            berry.isRipe = false;
            berry.isSpoiled = false;

            strawberries.Add(berry);
        }


        Debug.Log($"Симуляция стартовала: {strawberries.Count} кустов, pH = {pH:F1}");
        UpdateVisuals();
    }

    // Включение лампы
    public void TurnOnLamp()
    {
        lampIntensity = 1f;
        Debug.Log("Лампа включена");
    }

    // Регулировка pH через кнопки
    public void AdjustPH(float delta)
    {
        pH += delta;
        pH = Mathf.Clamp(pH, 3f, 8f);
        Debug.Log($"pH отрегулирован: {pH:F1}");
    }

    // Пропуск недели и расчёт роста
    public void SkipWeek()
    {
        if (currentWeek >= totalWeeks)
        {
            Debug.Log("Симуляция завершена");
            return;
        }

        foreach (var berry in strawberries)
        {
            if (lampIntensity > 0.5f && Mathf.Abs(pH - 6f) <= 1f)
            {
                float targetSize = (berry.finalSize == StrawberrySize.Medium) ? 0.6f : 1f;
                berry.size = Mathf.Min(berry.size + targetSize / totalWeeks, targetSize);
            }
            else
            {
                float spoilChance = 0.2f + 0.3f * Mathf.Abs(pH - 6f);
                if (Random.value < spoilChance)
                {
                    berry.isSpoiled = true;
                    Debug.Log($"{berry.name} испортилась!");
                }
            }

            if (currentWeek == totalWeeks - 1 && !berry.isSpoiled)
                berry.isRipe = true;
        }

        currentWeek++;
        lampIntensity = 0f;
        pH += Random.Range(pHDeviationMin, pHDeviationMax);

        UpdateVisuals();
        Debug.Log($"Неделя {currentWeek} началась, pH = {pH:F1}, лампа выключена");
    }

    void UpdateVisuals()
    {
        foreach (var berry in strawberries)
        {
            if (berry.visual != null)
            {
                // Размер
                berry.visual.transform.localScale = Vector3.one * berry.size;

                // Цвет
                var renderer = berry.visual.GetComponent<Renderer>();
                if (renderer != null)
                {
                    if (berry.isSpoiled)
                        renderer.material.color = Color.black;
                    else if (berry.isRipe)
                        renderer.material.color = Color.red;
                    else
                        renderer.material.color = Color.green;
                }
            }
        }
    }

    public int GetCurrentWeek() => currentWeek;
    public float GetPH() => pH;
}
