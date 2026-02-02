using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class AchievementPopup : MonoBehaviour
{
    public static AchievementPopup Instance { get; private set; }

    // Ссылка на саму панель окошка (объект Panel в иерархии)
    [SerializeField] private GameObject popupPanel;

    // Ссылка на текстовый элемент внутри окошка (куда будем писать "Достижение получено!")
    [SerializeField] private TMP_Text achievementText;

    // Ссылка на изображение для иконки достижения (маленькая картинка помидора)
    [SerializeField] private Image achievementIcon;

    // Сколько секунд показывать окошко (по умолчанию 3 секунды)
    [SerializeField] private float displayDuration = 3f;


    private void Awake()
    {
        // Проверяем: существует ли уже другой объект с этим скриптом?
        if (Instance == null)
        {
            // Если НЕТ — делаем этот объект "главным"
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Если УЖЕ есть другой объект с этим скриптом — уничтожаем этот (дубликат)
            Destroy(gameObject);
        }

        // Сразу прячем окошко при запуске игры (чтобы не мешалось)
        if (popupPanel != null)
            popupPanel.SetActive(false);  // false = скрыть, true = показать
    }


    public void ShowAchievement(string achievementName, Sprite icon = null)
    {

        if (popupPanel == null) return;


        popupPanel.SetActive(true);

        // ДОБАВЛЕНО: разный текст для разных достижений (ничего не удалено из старого кода)
        if (achievementName == "Мистер Помидор")
        {
            achievementText.text = "Достижение получено:\n" + "Уже говоришь с овощами?\n";
        }
        else if (achievementName == "Завтыкал")
        {
            achievementText.text = "Достижение получено:\n" + "Завтыкал\n";
        }

        // 3. Если передана иконка — показываем её
        if (icon != null && achievementIcon != null)
        {
            // Назначаем спрайт (картинку) для иконки
            achievementIcon.sprite = icon;
            // Включаем отображение иконки
            achievementIcon.gameObject.SetActive(true);
        }
        else if (achievementIcon != null)
        {
            achievementIcon.gameObject.SetActive(false);
        }


        Invoke("HidePopup", displayDuration);
    }


    private void HidePopup()
    {
        // Просто прячем панель
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}