using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackHall : MonoBehaviour
{
    public Image backgroundImage;              // Картинка фона
    public Sprite newPicture;
    public Sprite newPicture1;                  // Первая картинка для смены


    void Start()
    {
        if (GlobalVariables.Day1 && GlobalVariables.Day1BlackHall)
        {
            backgroundImage.sprite = newPicture;

        }
        if (GlobalVariables.flagWires == true)
        {
            backgroundImage.sprite = newPicture1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
