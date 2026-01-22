using UnityEngine;

public class SimpleClickTeleport : MonoBehaviour
{
    public static int cnt_wires = 0;
    public static bool flagWires = false; // флаг выполнено ли задание по починке проводов


    public GameObject objectToTeleport;
    public GameObject destroyArrow;

    public Vector3 targetPosition = new Vector3(10f, 10f, 10f);
    
    void OnMouseDown()
    {
        
        if (objectToTeleport != null)
        {
            objectToTeleport.transform.position = targetPosition; // перемещение объекта по z чтобы его было видно
            //Debug.Log("Телепортирован: " + objectToTeleport.name);
            cnt_wires ++;
            //Debug.Log("cnt ="+cnt_wires + ' ');
            Destroy(destroyArrow);
            if (cnt_wires >= 5)
            {   
                flagWires = true;
                cnt_wires = 0;
                if (flagWires == true && desappearanceOfGlass.flagGlass == true) 
                {
                    Days.Day ++;
                    SimpleButton.GoToSceneDay2();
                }
                else
                {
                    SimpleButton.GoToSceneHall();
            }}
        }
    }
}