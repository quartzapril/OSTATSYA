using UnityEngine;
using UnityEngine.SceneManagement;

public class Trash : MonoBehaviour
{
    public string nextSceneName;
    
    void Start()
    {
        if (!TryGetComponent<BoxCollider2D>(out var collider))
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
        }
        collider.isTrigger = true;
        collider.size = new Vector2(3, 3);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("2D объект в мусорке: " + other.name);
        
        if (other.GetComponent<SimpleDrag>() != null)
        {
            Destroy(other.gameObject);
            Debug.Log("Уничтожен: " + other.name);
            
            // Исправленная строка:
            if (FindObjectsOfType<SimpleDrag>().Length == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}