using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoints;
     Vector3 spawnOrigin;
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f,2f);
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(-4, 4);
        Vector3 spawnVec = new Vector3(spawnPoints.position.x, randomY, spawnPoints.position.z);

        Instantiate(enemyPrefabs[Random.Range(0, 3)], spawnVec, Quaternion.identity);
    }


    
}
