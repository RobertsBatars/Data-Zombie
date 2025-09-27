using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    void Start()
    {
        health = GameManager.instance.initialPlayerHealth; // Accessing the parameter
    }

    public void DamagePlayer(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
