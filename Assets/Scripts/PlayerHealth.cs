using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    private int maxHealth;
    void Start()
    {
        health = GameManager.instance.initialPlayerHealth; // Accessing the parameter
        maxHealth = health;
    }

    public void DamagePlayer(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    public void AddHealth(int healthAmount)
    {
        health = Mathf.Min(health + healthAmount, maxHealth);
    }
}
