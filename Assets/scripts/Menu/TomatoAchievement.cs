using UnityEngine;
using UnityEngine.UI;

public class TomatoAchievement : MonoBehaviour
{
    // Ссылка на иконку помидора (назначается в инспекторе)
    [SerializeField] private Image tomatoIcon;

    void Start()
    {
        // Проверяем статус достижения и обновляем видимость
        UpdateAchievementStatus();
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
        if (tomatoIcon != null)
        {
            tomatoIcon.gameObject.SetActive(GlobalVariables.TomatoAchievementUnlocked);
        }
    }
}