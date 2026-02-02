using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public static bool flagWires = false;

    public static bool DoneRoom1 = false; //выполнен диалог в комнате1
    public static bool DoneRoom2 =  false;
    public static bool DoneRoom3 = false;
    public static bool DoneRoom4 = false;
    public static bool DoneCabinet = false;


    public static bool DoneRoom11 = false; //выполнен диалог в комнате1
    public static bool DoneRoom12 = false;
    public static bool DoneRoom13 = false;
    public static bool DoneRoom14 = false;

    public static bool Day1BlackHall = true;

    public static bool TomatoFlag = false;
     public static bool CalFlag = false;

    public static bool TomatoAchievementUnlocked = false; //достижение помидор
    public static bool AchievementZavtykalUnlocked = false; //достижение завтыкал

    public static string previousScene = ""; // Хранит имя предыдущей сцены


    //public static bool DialogueAfter1 = false;


    public static bool Day0 = true; //флаг для дня 1
    public static bool Day1 = false;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
