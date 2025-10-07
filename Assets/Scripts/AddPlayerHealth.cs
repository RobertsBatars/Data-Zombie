using UnityEngine;

public class AddPlayerHealth : MonoBehaviour
{
    private int healthToAdd;
    private void Start()
    {
        healthToAdd = (int)(GameManager.instance.healthPickupAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.AddHealth(healthToAdd);
                Destroy(gameObject); // Destroy the health pickup after use
            }
        }
    }

}
