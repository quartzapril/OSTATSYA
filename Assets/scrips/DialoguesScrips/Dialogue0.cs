using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue0 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image backgroundImage; // Перетащи сюда Image из Canvas
    public Sprite newPicture; // Перетащи сюда новую картинку
    public Sprite newPicture1; 

    public string[] lines;
    public float textSpeed;
    private int index;
    public int index0;
    public int index1;
    public string sceneName1;

    void Start()
    {
        if (GlobalVariables.Day0)
        {
            textComponent.text = string.Empty;
            StartDialogue();
        }
    }

    void Update()
    {
        if (GlobalVariables.Day0 && Input.GetMouseButtonDown(0))
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
            
            // Меняем картинку на
            if (index == index0)
            {
                if (backgroundImage != null && newPicture != null)
                {
                    backgroundImage.sprite = newPicture;
                }
            }
            if (index == index1)
            {
                backgroundImage.sprite = newPicture1;
            }
        }
        else
        {

            switch (SceneManager.GetActiveScene().name)
            {
                case "Room1": GlobalVariables.DoneRoom1 = true; break;
                case "Room2": GlobalVariables.DoneRoom2 = true; break;
                case "Room3": GlobalVariables.DoneRoom3 = true; break;
                case "Room4": GlobalVariables.DoneRoom4 = true; break;
            }
            SceneManager.LoadScene(sceneName1);
            gameObject.SetActive(false);
        }
    }
}