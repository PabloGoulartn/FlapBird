using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [Header("Movement Settings")]
    [SerializeField] private float currentTiltAngle;
    [SerializeField] private short rotationSpeed;
    [SerializeField] private short jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        HandleBirdRotation();
    }

    void Jump()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void HandleBirdRotation()
    {
        if (rb.linearVelocity.y < 0)
        {
            if (currentTiltAngle > -90f)
            {
                currentTiltAngle = Mathf.Max(-80f, currentTiltAngle - Time.deltaTime * rotationSpeed);
                transform.rotation = Quaternion.Euler(0, 0, currentTiltAngle);
            }
        }
        if (rb.linearVelocity.y > 0 && currentTiltAngle < 45f)
        {
            currentTiltAngle = Mathf.Min(45f, currentTiltAngle + Time.deltaTime * rotationSpeed * 10);
            transform.rotation = Quaternion.Euler(0, 0, currentTiltAngle);
        }
    }
}
