using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleButton : MonoBehaviour
{
    public void GoToScene()
    {
        SceneManager.LoadScene("hero_room_scene");
    }
}