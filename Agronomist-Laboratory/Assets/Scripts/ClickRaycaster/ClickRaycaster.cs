using UnityEngine;

public class ClickRaycaster : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                // Выводим имя объекта в консоль
                Debug.Log("Кликнули на объект: " + hit.collider.name);

                IClickable clickable = hit.collider.GetComponent<IClickable>();
                if (clickable != null)
                {
                    clickable.OnClick();
                }
            }
        }
    }
}
