using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private float rotate;
    [SerializeField] private short speed;
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
            if (rotate > -90f)
            {
                rotate = Mathf.Max(-80f, rotate - Time.deltaTime * speed);
                transform.rotation = quaternion.Euler(0, 0, rotate * Time.deltaTime);
            }
        }
    }
}
