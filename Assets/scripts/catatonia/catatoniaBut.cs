using UnityEngine;
using UnityEngine.UI;

public class CheckKeysArray : MonoBehaviour
{
    public GameObject objectText;
    public static string[] keyNames = new string[] { 
        "A", "B", "C", 
        "Alpha1", "Alpha2", "Alpha3", // Цифры 1,2,3
        "Space", "Enter", "Escape"    // Специальные клавиши
    };
    void Update()

    {
        foreach (string keyName in keyNames)
        {
            if (System.Enum.TryParse<KeyCode>(keyName, true, out KeyCode keyCode))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    Debug.Log($"Нажато: {keyName}");
                    objectText.GetComponentInChildren<Text>().text = keyName;
                }
            }
        }
    }
}