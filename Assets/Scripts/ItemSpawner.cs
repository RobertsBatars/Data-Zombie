using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pistolPrefab;
    [SerializeField] private GameObject shotgunPrefab;
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private GameObject knifePrefab;
    [Space(10)]
    [SerializeField] private float pistolSpawnChance = 0.1f;
    [SerializeField] private float shotgunSpawnChance = 0.1f;
    [SerializeField] private float ammoSpawnChance = 0.5f;
    [SerializeField] private float healthSpawnChance = 0.2f;
    [SerializeField] private float knifeSpawnChance = 0.1f;
    [Space(10)]
    [SerializeField] private float globalSpawnChance = 0.5f;

    private List<Transform> spawnPositions;

    private void NormaliseSpawnChances()
    {
        float total = pistolSpawnChance + shotgunSpawnChance + ammoSpawnChance + healthSpawnChance + knifeSpawnChance;
        pistolSpawnChance /= total;
        shotgunSpawnChance /= total;
        ammoSpawnChance /= total;
        healthSpawnChance /= total;
        knifeSpawnChance /= total;
    }
    void Start()
    {
        NormaliseSpawnChances();
        globalSpawnChance *= GameManager.instance.itemSpawnChanceMultiplier;
        spawnPositions = new List<Transform>();
        foreach (Transform child in transform)
        {
            spawnPositions.Add(child);
        }
        SpawnItems();
    }

    private void SpawnItems() 
    {
        foreach (Transform spawnPoint in spawnPositions)
        {
            SpawnItem(spawnPoint.position);
        }
    }

    private void SpawnItem(Vector2 spawnPosition) { 
        if (Random.value > globalSpawnChance) return;
        float roll = Random.value;
        if (roll < pistolSpawnChance)
        {
            Instantiate(pistolPrefab, spawnPosition, Quaternion.identity);
        }
        else if (roll < pistolSpawnChance + shotgunSpawnChance)
        {
            Instantiate(shotgunPrefab, spawnPosition, Quaternion.identity);
        }
        else if (roll < pistolSpawnChance + shotgunSpawnChance + ammoSpawnChance)
        {
            Instantiate(ammoPrefab, spawnPosition, Quaternion.identity);
        }
        else if (roll < pistolSpawnChance + shotgunSpawnChance + ammoSpawnChance + healthSpawnChance)
        {
            Instantiate(healthPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(knifePrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
