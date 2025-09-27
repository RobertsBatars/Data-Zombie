using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isEnemyBullet = false;
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!isEnemyBullet)
            {
                collision.GetComponent<EnemyHealth>()?.DamageEnemy(damage);
                Destroy(gameObject); // Destroy if it collides with an enemy
            }
        }
        else if (collision.CompareTag("Player"))
        {
            if (isEnemyBullet)
            {
                Destroy(gameObject); // Destroy if it collides with the player
            }
        }
        else if (!collision.CompareTag("Bullet"))
        {
            // This means it collides with walls or other objects
            Destroy(gameObject);
        }
    }

}
