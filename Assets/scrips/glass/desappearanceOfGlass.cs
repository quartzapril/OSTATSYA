using UnityEngine;

public class desappearanceOfGlass : MonoBehaviour
{
    public int cnt_glass = 0;
    //private SimpleButton simpleButton; // Ссылка на объект

    void Start()
    {
        Debug.Log("Корзина активирована: " + gameObject.name);
        
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            Debug.Log("Collider2D: " + collider.enabled + ", IsTrigger: " + collider.isTrigger);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("⚡ Триггер сработал! Объект: " + other.name);
        
        // Уничтожаем ВСЕ объекты которые попадают в корзину (кроме самой корзины)
        if (other.gameObject != this.gameObject)
        {
            Debug.Log("🎯 Уничтожаем объект: " + other.name);
            Destroy(other.gameObject);
            cnt_glass ++;
            Debug.Log(cnt_glass + ' ');
            if (cnt_glass == 5)
            {
                SimpleButton.GoToSceneHall();
            }
        }
    }
}