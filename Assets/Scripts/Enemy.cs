using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;
    public float enemyHealth;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 moveDirection = (player.position - transform.position).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;

        if (rb.linearVelocity.sqrMagnitude > 0.01f)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("MoveX", moveDirection.x);
            animator.SetFloat("MoveY", moveDirection.y);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyHealth--;
            Destroy(collision.gameObject);
        }
    }
}