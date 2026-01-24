using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;
    void Start()
    {
        playerHealth = maxHealth;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth--;
            Debug.Log(playerHealth);

        }
    }
}
