using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletRange = 5f;
    public float bulletSpeed = 10f;
    public int damage = 1;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * bulletSpeed;
        if (gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            Debug.Log("Player Bullet Sound Triggered");
            AudioManager.instance.PlaySFX(AudioManager.instance.playerBullet);
        }
        else
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.enemyBullet);
        }
    }

    void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) >= bulletRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BossHealth boss = collision.gameObject.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
            Destroy(gameObject);
            return;
        }

        Destroy(gameObject);
    }
}