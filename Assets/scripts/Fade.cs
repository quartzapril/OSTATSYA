using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleFade : MonoBehaviour
{
    public Image blackScreen;
    
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(FadeScene(sceneName));
    }
    
    System.Collections.IEnumerator FadeScene(string sceneName)
    {
        // Затемняем экран
        for (float i = 0; i <= 1; i += 0.02f)
        {
            blackScreen.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
        
        // Меняем сцену
        SceneManager.LoadScene("1");
        
        // Осветляем экран
        for (float i = 1; i >= 0; i -= 0.02f)
        {
            blackScreen.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
    }
}