using UnityEngine;

public class SimpleClickTeleport : MonoBehaviour
{
    public static int cnt_wires = 0;
    //
    //

    public GameObject objectToTeleport;
    public Vector3 targetPosition = new Vector3(10f, 10f, 10f);
    
    void OnMouseDown()
    {
        // Этот метод сработает при клике на объекте с коллайдером
        Debug.Log("Клик по " + gameObject.name);
        
        if (objectToTeleport != null)
        {
            objectToTeleport.transform.position = targetPosition; // перемещение объекта
            Debug.Log("Телепортирован: " + objectToTeleport.name);
            cnt_wires ++;
            Debug.Log("cnt ="+cnt_wires + ' ');
            if (cnt_wires == 5)
            {   cnt_wires = 0;
                SimpleButton.GoToSceneHall();
            }
        }
    }
}