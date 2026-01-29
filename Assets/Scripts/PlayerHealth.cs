using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;

    void Start()
    {
        playerHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        AudioManager.instance.PlaySFX(AudioManager.instance.playerHit);
        Debug.Log("Player Health: " + playerHealth);

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
