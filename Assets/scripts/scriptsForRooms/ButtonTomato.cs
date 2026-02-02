using UnityEngine;
using TMPro;

public class ButtonTomato : MonoBehaviour
{
    [SerializeField] private TMP_Text textToShow;
    [SerializeField] private Sprite tomatoAchievementIcon;

    public void OnButtonClick()
    {
        if (textToShow != null)
        {
            // Показываем диалог
            textToShow.text = "Мистер Помидор. Я сначала был против того, чтобы брать тебя с собой. Но теперь я рад, что систр настояла на том, что с тобой тут будет поуютнее… Ох, мистер Помидор, у меня плохое предчувствие";
            textToShow.gameObject.SetActive(true);
            GlobalVariables.TomatoFlag = true;

            // Проверяем, получено ли достижение ранее
            if (!GlobalVariables.TomatoAchievementUnlocked)
            {
                // 1. Сохраняем флаг (статическая переменная сохраняется между сценами!)
                GlobalVariables.TomatoAchievementUnlocked = true;

                // 2. Показываем окошко достижения
                if (AchievementPopup.Instance != null)
                {
                    AchievementPopup.Instance.ShowAchievement("Мистер Помидор", tomatoAchievementIcon);
                }

                // 3. Опционально: сохраняем в PlayerPrefs для сохранения между запусками игры
                PlayerPrefs.SetInt("TomatoAchievementUnlocked", 1);
                PlayerPrefs.Save();
            }
        }
    }
}