using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UltraSimpleFade : MonoBehaviour
{
    public Image blackScreen;
    
    public void LoadWithFade(string sceneName)
    {
        // Включаем черный экран
        blackScreen.gameObject.SetActive(true);
        
        // Запускаем затемнение
        StartCoroutine(DoFade(sceneName));
    }
    
    System.Collections.IEnumerator DoFade(string sceneName)
    {
        // Затемняем экран за 0.5 секунды
        for (int i = 0; i <= 10; i++)
        {
            blackScreen.color = new Color(0, 0, 0, i * 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
        
        // Полностью черный экран
        blackScreen.color = Color.black;
        
        // Меняем сцену
        SceneManager.LoadScene(sceneName);
        
        // После загрузки сцены экран останется черным
        // Чтобы его убрать, нужно вызвать FadeIn в новой сцене
    }
}