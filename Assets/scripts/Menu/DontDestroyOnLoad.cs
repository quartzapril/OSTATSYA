using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad instance; // Единственный экземпляр

    void Start()
    {
        // Проверяем, существует ли уже экземпляр
        if (instance != null)
        {
            // Если да — уничтожаем дубликат
            Destroy(gameObject);
        }
        else
        {
            // Если нет — сохраняем текущий объект как единственный
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при смене сцены
        }
    }
}