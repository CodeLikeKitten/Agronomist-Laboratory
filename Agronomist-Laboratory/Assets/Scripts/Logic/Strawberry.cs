using UnityEngine;

public enum StrawberrySize
{
    Medium,
    Large
}

[System.Serializable]
public class Strawberry
{
    public string name;
    public float size = 0.2f; // стартовый размер (маленькая)
    public StrawberrySize finalSize;
    public bool isRipe = false;
    public bool isSpoiled = false;
    public GameObject visual; // объект на сцене (куст или капсула)
}
