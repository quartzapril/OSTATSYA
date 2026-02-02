using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackHall : MonoBehaviour
{
    public Image backgroundImage;              // Картинка фона
    public Sprite newPicture;
    public Sprite newPicture1;                  // Первая картинка для смены

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "1" && GlobalVariables.Day1 && GlobalVariables.Day1BlackHall)
        {
            backgroundImage.sprite = newPicture;
        }
        
        if (SceneManager.GetActiveScene().name == "1" && GlobalVariables.flagWires == true)
        {
            backgroundImage.sprite = newPicture1;
        }

        if (SceneManager.GetActiveScene().name == "DaysNames")
        {
            if (GlobalVariables.Day0 == true)
            {
                backgroundImage.sprite = newPicture;
            }
            else if (GlobalVariables.Day1 == true)
            {
                backgroundImage.sprite = newPicture1;
            }
            
            // Запускаем таймер на 10 секунд
            StartCoroutine(TenSecondTimer());
        }
    }

    IEnumerator TenSecondTimer()
    {
        // Ждем 10 секунд
        yield return new WaitForSeconds(5f);
        
        Debug.Log("5 секунд прошло!");
        SceneManager.LoadScene("HeroRoomScene");
    }

    void Update()
    {
        
    }
}