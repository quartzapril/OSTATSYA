using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitGame : MonoBehaviour
{
    [Header("Настройки затемнения")]
    [SerializeField] private Image fadeImage;          // Чёрный Image для затемнения
    [SerializeField] private float fadeDuration = 1f;  // Длительность затемнения в секундах

    private bool isQuitting = false;                   // Флаг, чтобы предотвратить многократные вызовы

    public void QuitGame()
    {
        

        // Если уже выходим - игнорируем повторные нажатия
        if (isQuitting)
        {
            
            return;
        }

        isQuitting = true;
        

        StartCoroutine(FadeAndQuit());
        
    }

    private IEnumerator FadeAndQuit()
    {
       

        // Если нет fadeImage - выходим сразу
        if (fadeImage == null)
        {
           
            ExecuteQuit();
            yield break;
        }

        // Активируем Image если он не активен
        if (!fadeImage.gameObject.activeSelf)
        {
            
            fadeImage.gameObject.SetActive(true);
        }
        
        
        // Устанавливаем начальные значения
        fadeImage.color = new Color(0, 0, 0, 0);
        

        // Плавное затемнение
        float timer = 0f;
       

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);

            // Выводим прогресс каждые 0.2 секунды
            if (Mathf.Approximately(timer % 0.2f, 0))
            {
                Debug.Log($"Прогресс затемнения: {alpha:P0}");
            }

            yield return null; // Ждём следующий кадр
        }

        // Гарантируем полную непрозрачность
        fadeImage.color = Color.black;
        

        // Небольшая пауза на чёрном экране
        
        yield return new WaitForSeconds(0.5f);

        // Выполняем выход
       
        ExecuteQuit();
    }

    private void ExecuteQuit()
    {
        

#if UNITY_EDITOR
           
            UnityEditor.EditorApplication.isPlaying = false;
#else
       
        Application.Quit();
#endif
    }
}