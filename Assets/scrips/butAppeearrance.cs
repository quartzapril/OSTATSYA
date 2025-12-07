using UnityEngine;

public class butAppearance : MonoBehaviour
{
    public GameObject but;          // Объект для перемещения
    public Vector3 showPosition;    // Позиция когда объект в триггере
    public Vector3 hidePosition;    // Позиция когда объект вне триггера
    
    void Start()
    {
        if (but != null)
        {
            // Сразу прячем объект
            but.transform.position = hidePosition;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (but != null)
        {
            // Показываем объект
            but.transform.position = showPosition;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (but != null)
        {
            // Прячем объект
            but.transform.position = hidePosition;
        }
    }
}