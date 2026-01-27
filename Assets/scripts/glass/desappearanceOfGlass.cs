using UnityEngine;

public class desappearanceOfGlass : MonoBehaviour
{
    public int cnt_glass = 0;
    //private SimpleButton simpleButton; // Ссылка на объект
    public Vector3 targetPositionBin = new Vector3(1826f, -495f, 0f);
    public static bool flagGlass = false; // флаг выполнено ли задание по сбору стекла

    void Start()
    {
        //Debug.Log("Корзина активирована: " + gameObject.name);
        
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            //Debug.Log("Collider2D: " + collider.enabled + ", IsTrigger: " + collider.isTrigger);
        }
    }

    void OnTriggerEnter2D(Collider2D other) // уничтожаем объект
    {
        if (other.gameObject != this.gameObject)
        {
            Destroy(other.gameObject);
            cnt_glass ++;
            Debug.Log(cnt_glass + ' ');
            if (cnt_glass == 5)
            {
                cnt_glass = 0;
                flagGlass = true;
                SimpleButton.GoToSceneHall();
            }
            
        }
    }
}