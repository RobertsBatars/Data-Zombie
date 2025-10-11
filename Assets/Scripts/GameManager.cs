using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Space(10)]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameStartScreen;

    [Space(10)]
    [Header("Difficulty Parameters")]
    // Parameters to be altered by the Game Alterer
    public int initialPlayerHealth = 100;
    public int enemyDamageMultiplier = 1;
    public int enemyHealthMultiplier = 1;
    public float EnemiesPerSecondMultiplier = 1f;
    public float EnemySpawnRateMultiplierPerSecond = 1.01f; // 1% increase per second
    public float itemSpawnChanceMultiplier = 1f;
    public float healthPickupAmount = 20;
    public int ammoPickupAmount = 10;

    [Space(10)]
    [Header("Session Statistics")]
    // Game statistics
    public float gameDuration = 0; // in seconds
    public int enemiesDefeated = 0; // total number of enemies defeated
    public int totalDamageDealt = 0; // total amount of damage the player has dealt to enemies
    public int totalDamageTaken = 0; // total amount of damage the player has taken
    public int totalHealthRecovered = 0; // total amount of health the player has recovered
    public int totalAmmoCollected = 0; // total amount of ammo the player has collected
    public int totalAmmoUsed = 0; // total amount of ammo the player has used
    public int totalWeaponUses = 0; // total amount of times the player pressed the fire button and uses weapon including knife
    public int totalTimesEnemiesDamaged = 0; // one enemy can be damaged multiple times, this counts each time an enemy is damaged

    [Space(10)]
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
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        gameStartScreen.SetActive(false);
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VoteTooEasy()
    {
        Reload();
    }

    public void VoteABitTooEasy()
    {
        Reload();

    }

    public void VoteJustRight()
    {
        Reload();

    }

    public void VoteABitTooHard()
    {
        Reload();

    }

    public void VoteTooHard()
    {
        Reload();

    }
}
