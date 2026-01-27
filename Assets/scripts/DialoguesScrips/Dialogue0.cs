using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue0 : MonoBehaviour
{
    // Компоненты UI
    public TextMeshProUGUI textComponent;      // Поле для текста диалога
    public Image backgroundImage;              // Картинка фона
    public Sprite newPicture;                  // Первая картинка для смены
    public Sprite newPicture1;                 // Вторая картинка для смены
    
    // Настройки диалога
    public string[] lines;                     // Строки диалога
    public float textSpeed;                    // Скорость печати
    private int index;                         // Номер текущей строки
    public int index0;                         // Когда менять на первую картинку
    public int index1;                         // Когда менять на вторую картинку
    public string sceneName1;                  // Куда переходить после диалога
    
    // Для затемнения
    private Image fadeImage;                   // Черный экран для перехода

    void Start()
    {
        CreateFadeImage();
        
        if (GlobalVariables.Day0)
        {
            textComponent.text = string.Empty;
            StartDialogue();
        }
    }

    // Проверяем клик мыши в каждом кадре
    void Update()
    {
        if (GlobalVariables.Day0 && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    // Начинаем диалог с первой строки
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    // Печатаем текст по буквам
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // Переходим к следующей строке или заканчиваем диалог
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
            // Меняем картинку фона
            if (index == index0 && backgroundImage != null && newPicture != null)
            {
                backgroundImage.sprite = newPicture;
            }
            if (index == index1 && backgroundImage != null && newPicture1 != null)
            {
                backgroundImage.sprite = newPicture1;
            }
        }
        else // Диалог закончился
        {
            // Сохраняем прогресс
            switch (SceneManager.GetActiveScene().name)
            {
                case "Room1": GlobalVariables.DoneRoom1 = true; break;
                case "Room2": GlobalVariables.DoneRoom2 = true; break;
                case "Room3": GlobalVariables.DoneRoom3 = true; break;
                case "Room4": GlobalVariables.DoneRoom4 = true; break;
            }
            
            // Затемняем и переходим
            StartCoroutine(FadeAndLoad());
        }
    }
    
    // Создаем черный экран для затемнения
    void CreateFadeImage()
    {
        fadeImage.raycastTarget = false; 
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("FadeCanvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
        }
        
        GameObject fadeObj = new GameObject("FadeImage");
        fadeObj.transform.SetParent(canvas.transform);
        
        fadeImage = fadeObj.AddComponent<Image>();
        fadeImage.color = new Color(0, 0, 0, 0);
        
        RectTransform rt = fadeObj.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
        
        fadeObj.transform.SetAsLastSibling();
    }
    
    // Плавно затемняем экран и меняем сцену
    IEnumerator FadeAndLoad()
    {
        if (fadeImage == null)
        {
            CreateFadeImage();
        }
        
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
        
        yield return new WaitForSeconds(0.2f);
        
        SceneManager.LoadScene(sceneName1);
    }
}