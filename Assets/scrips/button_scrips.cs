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
     public static void GoToSceneWires()
    {
        SceneManager.LoadScene("wires");
    }
    public static void GoToSceneGlass()
    {
        SceneManager.LoadScene("glass");
    }
     public static void GoToSceneDay2()
    {
        SceneManager.LoadScene("day2");
    }
}

