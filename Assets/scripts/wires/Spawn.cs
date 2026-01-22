using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnObject;
    public Camera camera;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 - Левая кнопка мыши
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Расстояние от камеры
            Vector3 worldPosition = camera.ScreenToWorldPoint(mousePosition);
            
            Instantiate(spawnObject, worldPosition, Quaternion.identity);
        }
    }
}