using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleButton : MonoBehaviour
{
    public static void GoToSceneHeroRoom()
    {
        SceneManager.LoadScene("hero_room_scene");
    }

    public static void GoToSceneHall()
    {
        SceneManager.LoadScene("1");
    }
        public static void GoToScenePuzzles()
    {
        SceneManager.LoadScene("puzzles");
    }
}

