using UnityEngine;

public class SimpleDrag : MonoBehaviour
{
    private Vector3 offset;
    
    void Start()
    {
        // УБРАЛИ установку тега - используем существующие теги
        // Автоматически добавляем Collider2D если его нет
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
            Debug.Log("Добавлен Collider2D на " + gameObject.name);
        }
    }
    
    
    void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePos;
    }
    
    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, 0);
    }
}