using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue2 : MonoBehaviour // скрипт для диалогов 2 дня
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    public int cnt = 2;
   

    void Start()
    {
        if (globalVariables.Day2){
            textComponent.text = string.Empty;
            StartDialogue();
    }
    }


    void Update()
    {
        if (globalVariables.Day2){
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
                if (cnt == 0)
            {
                    switch (SceneManager.GetActiveScene().name)
                    {
                        case "room1":
                            globalVariables.doneRoom1 = true;
                            Debug.Log("doneRoom1");
                            break;
                        case "room2":
                            globalVariables.doneRoom2 = true;
                            break;
                        case "room3":
                            globalVariables.doneRoom3 = true;
                            break;
                        case "room4":
                            globalVariables.doneRoom4 = true;
                            break;
                    }
                //SceneManager.LoadScene("1");
            }
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
            gameObject.SetActive(false);
            
        }
    }
}