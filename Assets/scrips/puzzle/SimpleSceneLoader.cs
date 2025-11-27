using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneLoader : MonoBehaviour
{
    // Простой метод для кнопки
    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }
}