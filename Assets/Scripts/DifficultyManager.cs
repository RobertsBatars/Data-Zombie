using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    // These variables will hold the randomized values for the current session.
    // They are public so the DataLogger can access them.
    [Header("Current Session Parameters")]
    public float enemyDamageMultiplier;
    public float enemyHealthMultiplier;
    public float enemiesPerSecondMultiplier;
    public float enemySpawnRateMultiplierPerSecond;
    public float itemSpawnChanceMultiplier;
    public float healthPickupAmount;
    public int ammoPickupAmount;
    public float playerSpeed;

    // You can tweak these ranges in the Inspector to control the experiment.
    [Header("Randomization Ranges")]
    [SerializeField] private Vector2 enemyDamageMultiplierRange = new Vector2(1, 8);
    [SerializeField] private Vector2 enemyHealthMultiplierRange = new Vector2(1, 8);
    [SerializeField] private Vector2 enemiesPerSecondRange = new Vector2(0.5f, 3.0f);
    [SerializeField] private Vector2 spawnRampUpRange = new Vector2(1.005f, 1.04f);
    [SerializeField] private Vector2 itemChanceRange = new Vector2(0.4f, 2.5f);
    [SerializeField] private Vector2 healthPickupRange = new Vector2(10f, 50f);
    [SerializeField] private Vector2Int ammoPickupRange = new Vector2Int(5, 40);
    [SerializeField] private Vector2 playerSpeedRange = new Vector2(3f, 15f);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// This is the single public function to be called by the GameManager.
    /// It randomizes all difficulty parameters and applies them to the GameManager instance.
    /// </summary>
    /// <param name="gm">The instance of the current GameManager.</param>
    public void ApplyDifficulty(GameManager gm)
    {
        // 1. Randomize all parameters and store them in this script's public variables.
        enemyDamageMultiplier = Random.Range(enemyDamageMultiplierRange.x, enemyDamageMultiplierRange.y + 1);
        enemyHealthMultiplier = Random.Range(enemyHealthMultiplierRange.x, enemyHealthMultiplierRange.y + 1);
        enemiesPerSecondMultiplier = Random.Range(enemiesPerSecondRange.x, enemiesPerSecondRange.y);
        enemySpawnRateMultiplierPerSecond = Random.Range(spawnRampUpRange.x, spawnRampUpRange.y);
        itemSpawnChanceMultiplier = Random.Range(itemChanceRange.x, itemChanceRange.y);
        healthPickupAmount = Random.Range(healthPickupRange.x, healthPickupRange.y);
        ammoPickupAmount = Random.Range(ammoPickupRange.x, ammoPickupRange.y + 1);
        playerSpeed = Random.Range(playerSpeedRange.x, playerSpeedRange.y);

        // 2. Apply these randomized values to the GameManager's public variables.
        gm.enemyDamageMultiplier = this.enemyDamageMultiplier;
        gm.enemyHealthMultiplier = this.enemyHealthMultiplier;
        gm.EnemiesPerSecondMultiplier = this.enemiesPerSecondMultiplier;
        gm.EnemySpawnRateMultiplierPerSecond = this.enemySpawnRateMultiplierPerSecond;
        gm.itemSpawnChanceMultiplier = this.itemSpawnChanceMultiplier;
        gm.healthPickupAmount = this.healthPickupAmount;
        gm.ammoPickupAmount = this.ammoPickupAmount;
        gm.playerSpeed = this.playerSpeed;

        Debug.Log("New difficulty parameters randomized and applied to GameManager.");
    }

    /// <summary>
    /// Called by the GameManager when the player votes. Its only job is to trigger the DataLogger.
    /// </summary>
    /// <param name="feedbackValue">The player's vote (1-5).</param>
    public void ProcessPlayerVote(int feedbackValue)
    {
        DataLogger.instance.LogSessionData(feedbackValue);
    }
}

