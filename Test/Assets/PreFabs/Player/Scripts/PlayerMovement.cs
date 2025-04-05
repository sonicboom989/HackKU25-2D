using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Movement
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;
    public Animator am;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>(); // ✅ Auto-assign the Animator
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        FlipSprite();
        UpdateAnimatorDirection();
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

    void UpdateAnimatorDirection()
    {
        bool isWalking = moveDir.x != 0 || moveDir.y != 0;
        am.SetBool("isWalking", isWalking);

        if (moveDir.y > 0.1f)
        {
            am.SetInteger("Direction", 1);  // Up
            Debug.Log("Walking backward (up)");
        }
        else if (moveDir.y < -0.1f)
        {
            am.SetInteger("Direction", -1); // Down
            Debug.Log("Walking forward (down)");
        }
        else
        {
            am.SetInteger("Direction", 0);  // Side
            Debug.Log("Walking side or idle");
        }
    }
}
