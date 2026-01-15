using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue1 : MonoBehaviour // скрипт для диалогов 11 дня
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    public int cnt = 2;
    public int cntPause = 0;
   

    void Start()
    {
        if (GlobalVariables.Day1){
            textComponent.text = string.Empty;
            StartDialogue();
    }
    }


    void Update()
    {
        if (GlobalVariables.Day1){
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
                cnt --;
            //     if (cnt == cntPause)
            // {
            //         switch (SceneManager.GetActiveScene().name)
            //         {
            //             case "Room1":
            //                 GlobalVariables.DoneRoom1 = true;
            //                 Debug.Log("doneRoom1");
            //                 break;
            //             case "Room2":
            //                 GlobalVariables.DoneRoom2 = true;
            //                 break;
            //             case "Room3":
            //                 GlobalVariables.DoneRoom3 = true;
            //                 break;
            //             case "Room4":
            //                 GlobalVariables.DoneRoom4 = true;
            //                 break;
            //         }
            //     SceneManager.LoadScene("1");
            //}
            } 
    }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //SceneManager.LoadScene("1");
            gameObject.SetActive(false);
            
        }
    }
}