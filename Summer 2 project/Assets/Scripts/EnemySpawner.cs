using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{
   private Vector3 spawnPos;
   public GameObject enemyPrefab;

   [SerializeField] private float spawnRangeX = 8.5f;
   [SerializeField] private float spawnRangeZ = 8.5f;
   [SerializeField] private float spawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        InvokeRepeating("SpawnEnemy", 5.0f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity, gameObject.transform);
    }
}
