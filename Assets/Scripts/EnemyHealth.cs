using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;

    private SpriteRenderer spriteRenderer;
    private bool isDead = false;
    void Start()
    {
        health *= GameManager.instance.enemyHealthMultiplier;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageEnemy(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            if (!isDead) 
            {
                GameManager.instance.enemiesDefeated++;
                isDead = true;
                Destroy(gameObject);
            }
        }
        else
        {
            FlashRed();
        }
    }

    private void FlashRed()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            Invoke("ResetColor", 0.1f);
        }
    }

    private void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
