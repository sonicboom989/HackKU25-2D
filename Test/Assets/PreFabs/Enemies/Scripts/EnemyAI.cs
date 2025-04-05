using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        // Move towards player
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);

        // Update animation
        bool isMoving = direction.magnitude > 0.01f;
        animator.SetBool("move", isMoving);

        // Flip enemy sprite
        if (direction.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = direction.x > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        if (player != null)
        {
            // Flip sprite based on horizontal position
            Vector3 scale = transform.localScale;
            if (player.position.x > transform.position.x)
                scale.x = Mathf.Abs(scale.x);   // Face right
            else
                scale.x = -Mathf.Abs(scale.x);  // Face left

            transform.localScale = scale;
        }

    }

}
