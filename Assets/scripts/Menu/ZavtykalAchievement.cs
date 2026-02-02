using UnityEngine;
using UnityEngine.UI;

public class ZavtykalAchievement : MonoBehaviour
{
    // Ссылка на иконку завтыкала (назначается в инспекторе)
    [SerializeField] private Image zavtykalIcon;

    void Start()
    {
        // Проверяем статус достижения и обновляем видимость
        UpdateAchievementStatus();
        
        // Загружаем сохранённое состояние из PlayerPrefs (между запусками игры)
        if (PlayerPrefs.HasKey("AchievementZavtykalUnlocked"))
        {
            GlobalVariables.AchievementZavtykalUnlocked = 
                PlayerPrefs.GetInt("AchievementZavtykalUnlocked") == 1;
        }
    }

    // Вызывается, когда пользователь открывает меню достижений
    public void OnPanelOpen()
    {
        UpdateAchievementStatus();
    }

    // Обновляем видимость иконки
    private void UpdateAchievementStatus()
    {
        // Показываем иконку ТОЛЬКО если достижение получено
        if (zavtykalIcon != null)
        {
            zavtykalIcon.gameObject.SetActive(GlobalVariables.AchievementZavtykalUnlocked);
        }
    }
}