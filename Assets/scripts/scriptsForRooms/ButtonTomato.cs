using UnityEngine;
using TMPro; // Только заменили using UnityEngine.UI на TMPro

public class ShowTextOnClick : MonoBehaviour
{
    [SerializeField] private TMP_Text textToShow; // Заменили Text на TMP_Text

    void Start()
    {
        // Скрываем текст при старте
        if (textToShow != null)
            textToShow.gameObject.SetActive(false);
    }

    // Этот метод будет вызван при нажатии кнопки
    public void OnButtonClick()
    {
        if (textToShow != null)
        {
            textToShow.text = "Мистер Помидор. Я сначала был против того, чтобы брать тебя с собой. Но теперь я рад, что систр настояла на том, что с тобой тут будет поуютнее… Ох, мистер Помидор, у меня плохое предчувствие"; // Устанавливаем текст
            textToShow.gameObject.SetActive(true); // Показываем текст
            GlobalVariables.TomatoFlag = true;
        }
    }
}