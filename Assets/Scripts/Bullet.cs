using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletRange = 5f;
    public float bulletSpeed = 10f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * bulletSpeed;
    }

    void Update()
    {
        float distanceTraveled = Vector3.Distance(startPosition, transform.position);

        if (distanceTraveled >= bulletRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.layer == LayerMask.NameToLayer("Enemy Bullet"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
                if (health != null) health.TakeDamage(1);
                Destroy(gameObject);
                return;
            }
        }

        if (gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {     
                Destroy(gameObject);
                return;
            }
        }

        Destroy(gameObject);
    }
}
