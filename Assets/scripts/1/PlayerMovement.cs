using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // ИЗМЕНИТЕ В ИНСПЕКТОРЕ!
    
    private Rigidbody2D rb;
    private Vector2 moveInput;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D не найден!");
            return;
        }
        
        // Важные настройки
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
    }
    
    void FixedUpdate()
    {
        // Движение с автоматической обработкой коллизий
        rb.linearVelocity = moveInput * moveSpeed;
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        
        // Ограничиваем диагональную скорость
        if (moveInput.magnitude > 1f)
        {
            moveInput.Normalize();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"СТОЛКНУЛСЯ С: {collision.gameObject.name}");
    }
}