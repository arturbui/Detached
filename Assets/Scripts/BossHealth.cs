using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 10;

    public void TakeDamage(int amount)
    {
        health -= amount;

        
        Debug.Log("Boss Hit! Current Health: " + health);

        if (health <= 0)
        {
            Debug.Log("Boss Defeated!");
            Destroy(gameObject);
        }
    }
}