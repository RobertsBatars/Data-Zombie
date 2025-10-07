using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Parameters to be altered by the Game Alterer
    public int initialPlayerHealth = 100;
    public int enemyDamageMultiplier = 1;
    public int enemyHealthMultiplier = 1;
    public float EnemiesPerSecondMultiplier = 1f;
    public float EnemySpawnRateMultiplierPerSecond = 1.01f; // 1% increase per second
    public float itemSpawnChanceMultiplier = 1f;
    public float healthPickupAmount = 20;
    public int ammoPickupAmount = 10;

    // Game statistics
    public float gameDuration = 0; // in seconds
    public int enemiesDefeated = 0;

    // Game state
    public bool isGameOver = false;

    private void Update()
    {
        if (!isGameOver)
        {
            gameDuration += Time.deltaTime;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
