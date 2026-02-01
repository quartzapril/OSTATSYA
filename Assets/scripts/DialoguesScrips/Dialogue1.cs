using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic; 

public class Dialogue1 : MonoBehaviour
{
    // Компоненты UI
    public TextMeshProUGUI textComponent;      // Поле для текста диалога
    public Image backgroundImage;              // Картинка фона
    public Sprite newPicture;                  // Первая картинка для смены
    public Sprite newPicture1;                 // Вторая картинка для смены
    public Sprite newPicture0;                 // Картинка для смены в самом начале
    public Image Image; //Для удаления существующей картинки персонажа
    
    // Настройки диалога
    public string[] lines;                     // Строки диалога
    public float textSpeed;                    // Скорость печати
    public static int index;                         // Номер текущей строки
    public int index0;                         // Когда менять на первую картинку
    public int index1;                         // Когда менять на вторую картинку
    public string sceneName1;                  // Куда переходить после диалога
    
    // Для затемнения
    private Image fadeImage;                   // Черный экран для перехода
    private Color originalColor0;

    void Start()
    {
        originalColor0 = Image.color;

        if (SceneManager.GetActiveScene().name == "room1" || SceneManager.GetActiveScene().name == "room2")
        {
            backgroundImage.sprite = newPicture0;
            Color originalColor = Image.color;
            originalColor.a = 0f;
            Image.color = originalColor;
        }
        
        CreateFadeImage();
        
        if (GlobalVariables.Day1)
        {
            textComponent.text = string.Empty;
            StartDialogue();
        }
    }

    // Проверяем клик мыши в каждом кадре
    void Update()
    {
        // ИЗМЕНИЛИ УСЛОВИЕ - проверяем не над UI ли клик
        if (GlobalVariables.Day1 && Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
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

    // НОВЫЙ МЕТОД - проверяет, находится ли курсор над UI объектом
    private bool IsPointerOverUIObject()
    {
        // Создаем событие для проверки
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        // Получаем список всех UI объектов под курсором
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        
        // Если есть UI объекты под курсором - возвращаем true
        return results.Count > 0;
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
            
            if (index == 2 && SceneManager.GetActiveScene().name == "HeroRoomScene")
            {
                GlobalVariables.CalFlag = true;
            }
            // Меняем картинку фона
            if (index == index0 && backgroundImage != null && newPicture != null)
            {
                if (SceneManager.GetActiveScene().name == "room2")
                {
                    Image.color = originalColor0;
                }
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
                case "Room1": GlobalVariables.DoneRoom11 = true; break;
                case "Room2": GlobalVariables.DoneRoom12 = true; break;
                case "Room3": GlobalVariables.DoneRoom13 = true; break;
                case "Room4": GlobalVariables.DoneRoom14 = true; break;
            }
            if (SceneManager.GetActiveScene().name == "Room4")
            {
                SceneManager.LoadScene("Tablet");
            }
            
            // Затемняем и переходим
            StartCoroutine(FadeAndLoad());
        }
    }
    
    // Создаем черный экран для затемнения
    void CreateFadeImage()
    {
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
        fadeImage.raycastTarget = false;
        
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