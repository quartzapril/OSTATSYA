using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour
{
    public string sceneName1 = "Cabinet";  // Сцена для перехода

    private Image fadeImage;               // Черный экран для перехода

    public void LoadStartGame()
    {
        StartCoroutine(FadeAndLoad());
    }

    
    IEnumerator FadeAndLoad()
    {
        // Создаем черный экран
        CreateFadeImage();

        // Активируем и затемняем
        fadeImage.gameObject.SetActive(true);

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

        // пауза - 0.2 секунды
        yield return new WaitForSeconds(0.2f);

        // Загружаем сцену
        SceneManager.LoadScene(sceneName1);
    }

    
    void CreateFadeImage()
    {
        // Если fadeImage уже создан, ничего не делаем
        if (fadeImage != null) return;

        // Ищем Canvas (как в диалоговом скрипте)
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("FadeCanvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
        }

        // Создаем черное изображение
        GameObject fadeObj = new GameObject("FadeImage");
        fadeObj.transform.SetParent(canvas.transform);

        fadeImage = fadeObj.AddComponent<Image>();
        fadeImage.color = new Color(0, 0, 0, 0);
        fadeImage.raycastTarget = false;

        // Растягиваем на весь экран
        RectTransform rt = fadeObj.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        fadeObj.transform.SetAsLastSibling(); // Поверх всего

        // Скрываем до использования
        fadeObj.SetActive(false);
    }

   
}