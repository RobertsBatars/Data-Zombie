using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Space(10)]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameStartScreen;
    [Space(10)]
    [SerializeField] private int sessionTimeSeconds = 60;
    [SerializeField] private Slider timeSlider;
    [SerializeField] private TMP_Text killsText;
    [SerializeField] private TMP_Text killsTextGameOverScreen;

    [Space(10)]
    [Header("Difficulty Parameters")]
    // Parameters to be altered by the Game Alterer
    public int initialPlayerHealth = 100;
    public float enemyDamageMultiplier = 1;
    public float enemyHealthMultiplier = 1;
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
    public int playerCurrentHealth = 0;

    [Space(10)]
    // Game state
    public bool isGameOver = false;

    private void Update()
    {
        if (!isGameOver)
        {
            gameDuration += Time.deltaTime;
            timeSlider.value = sessionTimeSeconds - gameDuration;
            killsText.text = "Kills: " + enemiesDefeated;
        }
        if (gameDuration >= sessionTimeSeconds && !isGameOver)
        {
            GameOver();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DifficultyManager.instance.ApplyDifficulty(this);
        Time.timeScale = 0;
        timeSlider.maxValue = sessionTimeSeconds;
        timeSlider.value = sessionTimeSeconds;
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
        killsTextGameOverScreen.text = "Kills: " + enemiesDefeated;
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VoteTooEasy()
    {
        DifficultyManager.instance.ProcessPlayerVote(1);
        Reload();
    }

    public void VoteABitTooEasy()
    {
        DifficultyManager.instance.ProcessPlayerVote(2);
        Reload();
    }

    public void VoteJustRight()
    {
        DifficultyManager.instance.ProcessPlayerVote(3);
        Reload();
    }

    public void VoteABitTooHard()
    {
        DifficultyManager.instance.ProcessPlayerVote(4);
        Reload();
    }

    public void VoteTooHard()
    {
        DifficultyManager.instance.ProcessPlayerVote(5);
        Reload();

    }
}
