using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject FatZombie;
    [SerializeField] private GameObject SkinnyZombie;
    [SerializeField] private GameObject KidZombie;
    [Space(10)]
    [SerializeField] private float FatZombieSpawnPercentage = 0.3f;
    [SerializeField] private float SkinnyZombieSpawnPercentage = 0.5f;
    [SerializeField] private float KidZombieSpawnPercentage = 0.2f;
    [SerializeField] private float EnemiesPerSecond = 1f;

    private List<Transform> spawners;
    private float timeSinceLastSpawn = 0f;
    private float timeSinceLastSpawnRateIncrease = 0f;
    void Start()
    {
        NormalisePercentages();
        spawners = new List<Transform>();
        foreach (Transform child in transform)
        {
            spawners.Add(child);
        }
        EnemiesPerSecond *= GameManager.instance.EnemiesPerSecondMultiplier;
    }

    private void NormalisePercentages()
    {
        float total = FatZombieSpawnPercentage + SkinnyZombieSpawnPercentage + KidZombieSpawnPercentage;
        FatZombieSpawnPercentage /= total;
        SkinnyZombieSpawnPercentage /= total;
        KidZombieSpawnPercentage /= total;
    }

    void Update()
    {
        int enemiesToSpawn = Mathf.FloorToInt(EnemiesPerSecond * Time.deltaTime + timeSinceLastSpawn);
        Transform spawner;

        timeSinceLastSpawnRateIncrease += Time.deltaTime;
        if (timeSinceLastSpawnRateIncrease >= 1f)
        {
            EnemiesPerSecond *= GameManager.instance.EnemySpawnRateMultiplierPerSecond;
            timeSinceLastSpawnRateIncrease = 0f;
        }

        if (enemiesToSpawn > 0)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                spawner = spawners[Random.Range(0, spawners.Count)];
                float rand = Random.Range(0f, 1f);
                if (rand < FatZombieSpawnPercentage)
                {
                    Instantiate(FatZombie, spawner.position, Quaternion.identity);
                }
                else if (rand < FatZombieSpawnPercentage + SkinnyZombieSpawnPercentage)
                {
                    Instantiate(SkinnyZombie, spawner.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(KidZombie, spawner.position, Quaternion.identity);
                }
            }
        }
        timeSinceLastSpawn += EnemiesPerSecond * Time.deltaTime - enemiesToSpawn;
    }
}
