using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;

    public Slider healthSlider;

    void Start()
    {
        playerHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = playerHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        if (healthSlider != null)
        {
            healthSlider.value = playerHealth;
        }

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