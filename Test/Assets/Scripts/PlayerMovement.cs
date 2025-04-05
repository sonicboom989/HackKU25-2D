using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Movement
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        FlipSprite();
    }

    void FixedUpdate()
    {
        Move();
    }


    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    void FlipSprite()
    {
        Vector3 scale = transform.localScale;

        if (moveDir.x > 0)
            scale.x = Mathf.Abs(scale.x);  // Ensure positive X
        else if (moveDir.x < 0)
            scale.x = -Mathf.Abs(scale.x); // Ensure negative X

        transform.localScale = scale;
    }
}
