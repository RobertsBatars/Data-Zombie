using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    private int health;
    private int maxHealth;
    void Start()
    {
        health = GameManager.instance.initialPlayerHealth; // Accessing the parameter
        maxHealth = health;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void DamagePlayer(int damageAmount)
    {
        health -= damageAmount;
        healthSlider.value = health;
        GameManager.instance.totalDamageTaken += Mathf.Min(damageAmount, health + damageAmount); // Only count damage that actually reduces health
        if (health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    public void AddHealth(int healthAmount)
    {
        int healthAdded = Mathf.Min(healthAmount, maxHealth - health);
        health = Mathf.Min(health + healthAmount, maxHealth);
        healthSlider.value = health;
        GameManager.instance.totalHealthRecovered += healthAdded;
    }
}
