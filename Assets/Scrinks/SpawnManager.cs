using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject chaser;
    public GameObject dasher;
    public GameObject rumbler;
    private float spawnRange = 9;

    void Start()
    {
        Instantiate(chaser, GenerateSpawnPosition(), chaser.transform.rotation);
        Instantiate(dasher, GenerateSpawnPosition(), dasher.transform.rotation);
        Instantiate(rumbler, GenerateSpawnPosition(), rumbler.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void Update()
    {
        
    }
}
