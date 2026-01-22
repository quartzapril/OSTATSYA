using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleButton : MonoBehaviour
{
    public static void GoToSceneHeroRoom()
    {
        SceneManager.LoadScene("HeroRoomScene");
    }

    public static void GoToSceneHall()
    {
        SceneManager.LoadScene("1");
    }
        public static void GoToScenePuzzles()
    {
        SceneManager.LoadScene("Puzzles");
    }
     public static void GoToSceneWires()
    {
        SceneManager.LoadScene("Wires");
    }
    public static void GoToSceneGlass()
    {
        SceneManager.LoadScene("Glass");
    }
     public static void GoToSceneDay2()
    {
        SceneManager.LoadScene("Day2");
    }
        public static void GoToSceneRoom1()
    {
        SceneManager.LoadScene("Room1");
    }
        public static void GoToSceneRoom2()
    {
        SceneManager.LoadScene("Room2");
    }
        public static void GoToSceneRoom3()
    {
        SceneManager.LoadScene("Room3");
    }
        public static void GoToSceneRoom4()
    {
        SceneManager.LoadScene("Room4");
    }
}

