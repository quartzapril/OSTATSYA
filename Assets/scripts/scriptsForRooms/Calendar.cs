using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Calendar : MonoBehaviour
{
    public Image ImageCal1;
    public Sprite ImageCal2;
    private int cnt = 0;

    void Start()
    {
        ImageCal1.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.CalFlag == true)
        {
            ImageCal1.gameObject.SetActive(true);
            if (Dialogue1.index == 3)
            {
            ImageCal1.sprite = ImageCal2;
            }
            if (Dialogue1.index == 4)
            {
                ImageCal1.gameObject.SetActive(false);
                GlobalVariables.CalFlag = false;
            }

        }
    }
}
