using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Movement
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;
    public Animator am;
    public GameObject dumbbellPrefab; // Drag prefab in Inspector
    public float throwForce = 10f;




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

        Vector3 spawnPos = transform.position + new Vector3(0, 0.5f, 0); // adjust Y as needed
        GameObject dumbbell = Instantiate(dumbbellPrefab, spawnPos, Quaternion.identity);
        Rigidbody2D rbDumbbell = dumbbell.GetComponent<Rigidbody2D>();

        if (rbDumbbell != null)
        {
            rbDumbbell.linearVelocity = throwDir * throwForce;
        }
    }

}
