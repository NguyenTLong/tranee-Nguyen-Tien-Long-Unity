using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    public float spawnRange = 9;
    public int enemyPerWave = 1;

    public int waveNumber = 0;

    private int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0)
        {
            spawnWave(enemyPerWave + waveNumber);
            spawnPowerUp(waveNumber);
            waveNumber++;
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    private void spawnWave(int numberOfEnemy)
    {
        for (int i = 1; i < numberOfEnemy; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private void spawnPowerUp( int numberOfPowerUp)
    {
        for (int i = 1; i < numberOfPowerUp; i++)
        {
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }
}
