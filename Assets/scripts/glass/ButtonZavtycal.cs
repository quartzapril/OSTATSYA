using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonZavtykal : MonoBehaviour
{
    [SerializeField] private Sprite zavtykalAchievementIcon; // Иконка для окошка достижения

    // Делаем объект неуничтожаемым при смене сцены
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Этот метод вызывается при нажатии кнопки Button2 (привязывается через OnClick)
    public void OnButtonClick()
    {
        // Проверяем, получено ли достижение ранее
        if (!GlobalVariables.AchievementZavtykalUnlocked)
        {
            // 1. Разблокируем достижение
            GlobalVariables.AchievementZavtykalUnlocked = true;

            // 2. Сохраняем между запусками игры
            PlayerPrefs.SetInt("AchievementZavtykalUnlocked", 1);
            PlayerPrefs.Save();

            // 3. Показываем окошко достижения
            if (AchievementPopup.Instance != null)
            {
                AchievementPopup.Instance.ShowAchievement("Завтыкал", zavtykalAchievementIcon);
            }
            else
            {
                Debug.Log("Получено достижение:\n Завтыкал");
            }

            // 4. ОТЛАЖИВАЕМ перезагрузку сцены 
            StartCoroutine(DelayedSceneReload(10f));
        }
        else
        {
            // Если достижение уже получено — перезагружаем сразу
            ReloadCurrentScene();
        }
    }

    // Корутина для отложенной перезагрузки
    private System.Collections.IEnumerator DelayedSceneReload(float delaySeconds)
    {
        // Используем реальное время (работает даже при смене сцены)
        yield return new WaitForSecondsRealtime(delaySeconds);
        ReloadCurrentScene();
    }

    // Перезагрузка текущей сцены
    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}