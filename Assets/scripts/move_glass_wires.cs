using UnityEngine;

public class SimpleDrag : MonoBehaviour
{
    private Vector3 offset;
    
    void Start()
    {
        // Автоматически добавляем Collider2D если его нет
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
            Debug.Log("Добавлен Collider2D на " + gameObject.name);
        }
    }
    
    
    void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Получает позицию мыши в мировых координатах
        offset = transform.position - mousePos; //Вычисляет смещение (offset) между позицией объекта и позицией мыши
    }
    
    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Получает текущую позицию мыши в мировых координатах
        transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, 0); //Устанавливает новую позицию объекта с учётом сохранённого смещения
    }
}