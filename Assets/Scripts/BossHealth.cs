using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int health = 10;
    public int maxHealth = 10;

    [Header("UI Elements")]
    public Slider bossHealthBar;
    public GameObject victoryScreen; 

    void Start()
    {
        if (bossHealthBar != null)
        {
            bossHealthBar.maxValue = maxHealth;
            bossHealthBar.value = health;
            bossHealthBar.gameObject.SetActive(true); 
        }

        if (victoryScreen != null) victoryScreen.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (bossHealthBar != null)
        {
            bossHealthBar.value = health;
        }

        if (health <= 0)
        {
            BossDefeated();
        }
    }

    void BossDefeated()
    {
        if (bossHealthBar != null) bossHealthBar.gameObject.SetActive(false);

        if (victoryScreen != null) victoryScreen.SetActive(true);

        Debug.Log("Victory!");

        Destroy(gameObject);
    }
}