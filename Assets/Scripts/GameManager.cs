using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Parameters to be altered by the Game Alterer
    public int initialPlayerHealth = 100;
    public int enemyDamageMultiplier = 1;
    public int enemyHealthMultiplier = 1;
    public float EnemiesPerSecondMultiplier = 1f;

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
