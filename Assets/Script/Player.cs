using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float rotate;
    [SerializeField] private short speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        HandleBirdRotation();
    }

    void HandleBirdRotation()
    {
        if (rb.linearVelocity.y < 0)
        {
            if (rotate > -45f)
            {
                rotate = Mathf.Max(-45f, rotate - Time.deltaTime * speed);
                transform.Rotate(0, 0, -Time.deltaTime * speed);
            }
        }
    }
}
