using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefads;
    public GameObject powerUp;

    private float zEnemySpawn = 12f;
    private float xSpawnRange = 8f;
    private float zPowerupRange = 5f;
    private float ySpawn = 0.75f;

    private float powerupSpawnTime = 5f;
    private float enemySpawnTime = 1f;
    private float startDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemyPrefads.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemyPrefads[randomIndex], spawnPos, Quaternion.identity);
    }

    private void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerUp, spawnPos, Quaternion.identity);
    }
}
