using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
