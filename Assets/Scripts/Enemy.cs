using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;
    public float enemyHealth;
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.0f;
    private float nextFireTime;

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

        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle - 90f);

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

        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
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
    

    void Shoot()
    {
        Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
    }
}