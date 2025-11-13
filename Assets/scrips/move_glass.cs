using UnityEngine;

public class SimpleDrag : MonoBehaviour
{
    void OnMouseDrag()
    {
        // Простой вариант с проверкой камеры
        if (Camera.main != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10; // Расстояние от камеры
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}