using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Movement
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;
    public Animator am;

    // Throwing
    public GameObject dumbbellPrefab;
    public float throwForce = 10f;

    // Animation direction
    private Vector2 lastMoveDir = Vector2.down; // Default facing down



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
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            ThrowDumbbell();
        }

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

        // Store last non-zero direction
        if (moveDir != Vector2.zero)
        {
            lastMoveDir = moveDir;
        }
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
        bool isWalking = moveDir != Vector2.zero;
        am.SetBool("isWalking", isWalking);

        if (lastMoveDir.y > 0.1f)
        {
            am.SetInteger("Direction", 1);  // Up
        }
        else if (lastMoveDir.y < -0.1f)
        {
            am.SetInteger("Direction", -1); // Down
        }
        else if (lastMoveDir.x != 0)
        {
            am.SetInteger("Direction", 0);  // Side
        }
    }
    void ThrowDumbbell()
    {
        if (dumbbellPrefab == null)
        {
            Debug.LogWarning("Dumbbell prefab not assigned!");
            return;
        }

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector2 throwDir = (mouseWorldPos - transform.position).normalized;

        Vector3 spawnPos = transform.position + new Vector3(0, 0.25f, 0); // adjust Y as needed
        GameObject dumbbell = Instantiate(dumbbellPrefab, spawnPos, Quaternion.identity);
        Rigidbody2D rbDumbbell = dumbbell.GetComponent<Rigidbody2D>();

        if (rbDumbbell != null)
        {
            rbDumbbell.linearVelocity = throwDir * throwForce;
        }
    }

}
