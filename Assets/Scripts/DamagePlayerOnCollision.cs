using UnityEngine;

public class DamagePlayerOnCollision : MonoBehaviour
{
    [SerializeField] private int damagePerSecond = 10;

    private float timeSinceLastDamage = 0f;
    void Start()
    {
        damagePerSecond *= GameManager.instance.enemyDamageMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastDamage += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                DamagePlayer(player);
                timeSinceLastDamage = 0f;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && timeSinceLastDamage >= 1f)
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                DamagePlayer(player);
                timeSinceLastDamage = 0f;
            }
        }
    }

    private void DamagePlayer(PlayerHealth player)
    {
        player.DamagePlayer(damagePerSecond);
    }
}
