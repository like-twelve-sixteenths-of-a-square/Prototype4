using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject foePrefab;
    public GameObject powerupPrefab;
    public int foeIndex;
    public int enemyCount;
    public int waveNumber = 1;
    private float spawnRange = 9;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), transform.rotation);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<LightEnemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }

    void SpawnEnemyWave(int foestoSpawn)
    {
        for (int i = 0; i < foestoSpawn; i++)
        {
            Instantiate(foePrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}