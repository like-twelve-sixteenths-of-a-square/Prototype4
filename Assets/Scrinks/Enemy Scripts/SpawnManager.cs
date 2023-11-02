using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foePrefabs;
    public GameObject powerupPrefab;
    public int foeIndex;
    public int enemyCount;
    public int goodie;
    public int waveNumber = 1;
    private float spawnRange = 9;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        int powerupChance = Random.Range(1, 6);
        if (powerupChance == 1)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Foe").Length;
        goodie = GameObject.FindGameObjectsWithTag("Powerup").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);

            int powerupChance = Random.Range(1, 6);
            if (powerupChance == 1 && goodie == 0)
            {
                Instantiate(powerupPrefab, GenerateSpawnPosition(), transform.rotation);
            }
        }
    }

    void SpawnEnemyWave(int foestoSpawn)
    {
        for (int i = 0; i < foestoSpawn; i++)
        {
            int foeIndex = Random.Range(0, foePrefabs.Length);
            Instantiate(foePrefabs[foeIndex], GenerateSpawnPosition(), transform.rotation);
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