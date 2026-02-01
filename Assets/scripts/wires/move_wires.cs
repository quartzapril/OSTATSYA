using UnityEngine;

public class SimpleClickTeleport : MonoBehaviour
{
    public static int cnt_wires = 0;
    //public static bool flagWires = false; // флаг выполнено ли задание по починке проводов


    public GameObject objectToTeleport; // Объект, который будет телепортирован при клике
    public GameObject destroyArrow; // Стрелка-подсказка, которая будет уничтожена после клика

    public Vector3 targetPosition = new Vector3(10f, 10f, 10f);
    
    void OnMouseDown() // Метод, вызываемый при нажатии кнопки мыши на коллайдере объекта
    {
        
        if (objectToTeleport != null)
        {
            objectToTeleport.transform.position = targetPosition; // перемещение объекта по z чтобы его было видно

            cnt_wires ++;
            Destroy(destroyArrow); //уничтожение объекта
            if (cnt_wires >= 5) // Проверяем, выполнено ли задание (исправлено 5 и более проводов)
            {   
                GlobalVariables.flagWires = true;
                cnt_wires = 0;
                SimpleButton.GoToSceneHall();
            }
        }
    }
}