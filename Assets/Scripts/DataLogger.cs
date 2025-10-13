using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;

public class DataLogger : MonoBehaviour
{
    public static DataLogger instance;
    public string FilePath { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            string fileName = $"gameplay_data_collection.csv";
            FilePath = Path.Combine(Application.persistentDataPath, fileName);
            UnityEngine.Debug.Log($"Data will be logged to: {FilePath}");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Logs all session data to a single CSV file. Always appends.
    /// </summary>
    /// <param name="playerFeedback">The player's vote (1-5).</param>
    public void LogSessionData(int playerFeedback)
    {
        if (GameManager.instance == null || DifficultyManager.instance == null) return;

        // --- 1. Get all Difficulty Parameters used in the session ---
        var dm = DifficultyManager.instance;
        var diffParams = new object[]
        {
            dm.enemyDamageMultiplier,
            dm.enemyHealthMultiplier,
            dm.enemiesPerSecondMultiplier,
            dm.enemySpawnRateMultiplierPerSecond,
            dm.itemSpawnChanceMultiplier,
            dm.healthPickupAmount,
            dm.ammoPickupAmount,
            dm.playerSpeed
        };

        // --- 2. Get all Player Performance Stats ---
        var gm = GameManager.instance;
        var perfStats = new object[]
        {
            gm.gameDuration,
            gm.enemiesDefeated,
            gm.totalDamageDealt,
            gm.totalDamageTaken,
            gm.totalHealthRecovered,
            gm.totalAmmoCollected,
            gm.totalAmmoUsed,
            gm.totalWeaponUses,
            gm.totalTimesEnemiesDamaged,
            gm.playerCurrentHealth
        };

        // --- 3. Combine all data into one array for logging ---
        var allValues = diffParams.Concat(perfStats).Concat(new object[] { playerFeedback }).ToArray();

        // --- 4. Format to CSV and Append to File ---
        string header = "enemyDamageMultiplier,enemyHealthMultiplier,enemiesPerSecondMultiplier,enemySpawnRateMultiplierPerSecond,itemSpawnChanceMultiplier,healthPickupAmount,ammoPickupAmount,playerSpeed," +
                        "gameDuration,enemiesDefeated,totalDamageDealt,totalDamageTaken,totalHealthRecovered,totalAmmoCollected,totalAmmoUsed,totalWeaponUses,totalTimesEnemiesDamaged,playerCurrentHealth," +
                        "playerFeedback\n";

        // Use a consistent format, replacing commas in floats with periods for CSV compatibility.
        string dataLine = string.Join(",", allValues.Select(v => v.ToString().Replace(",", "."))) + "\n";

        try
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, header);
            }
            File.AppendAllText(FilePath, dataLine);
            UnityEngine.Debug.Log("Session data successfully appended to CSV.");
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError($"Failed to log session data: {e.Message}");
        }
    }
}

