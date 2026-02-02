using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ResumeGame : MonoBehaviour
{
    private Image fadeImage;  // Черный экран для плавного перехода

    public void Resume()
    {
        // 1. Проверяем, что мы В МЕНЮ (имя сцены должно совпадать с вашим)
        if (SceneManager.GetActiveScene().name == "MainMENU")
        {
            // 2. Проверяем, что предыдущая сцена не пустая
            if (!string.IsNullOrEmpty(GlobalVariables.previousScene))
            {
                // 3. Загружаем предыдущую сцену
                StartCoroutine(FadeAndLoadPreviousScene());
            }
            else
            {
                Debug.LogError("Предыдущая сцена не сохранена! Проверьте скрипт перехода в меню.");
            }
        }
        else
        {
            Debug.LogWarning("Кнопка 'Продолжить игру' нажата не из меню. Остаемся здесь.");
        }

    }

    private IEnumerator FadeAndLoadPreviousScene()
    {
        // Создаём затемняющий экран (если ещё не создан)
        CreateFadeImage();
        fadeImage.gameObject.SetActive(true);

        // Плавно затемняем экран (0.8 секунды)
        float duration = 0.8f;
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / duration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = Color.black;

        // Короткая пауза для плавности
        yield return new WaitForSeconds(0.2f);

        // Загружаем сцену меню
        SceneManager.LoadScene(GlobalVariables.previousScene);
    }

    private void CreateFadeImage()
    {
        // Если экран уже создан — ничего не делаем
        if (fadeImage != null) return;

        // Ищем существующий Canvas в сцене
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            // Если нет — создаём новый
            GameObject canvasObj = new GameObject("FadeCanvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
            DontDestroyOnLoad(canvasObj); // Сохраняем между сценами
        }

        // Создаём чёрный экран
        GameObject fadeObj = new GameObject("FadeImage");
        fadeObj.transform.SetParent(canvas.transform, false);

        fadeImage = fadeObj.AddComponent<Image>();
        fadeImage.color = new Color(0, 0, 0, 0); // Прозрачный
        fadeImage.raycastTarget = false; // Не блокирует клики

        // Растягиваем на весь экран
        RectTransform rt = fadeObj.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        fadeObj.transform.SetAsLastSibling(); // Поверх всего интерфейса
        fadeObj.SetActive(false); // Скрываем до использования
    }

    // Создаём экран при старте сцены (но скрытым)
    private void Start()
    {
        CreateFadeImage();
    }
}
