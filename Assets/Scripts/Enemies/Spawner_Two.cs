using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Two : MonoBehaviour
{
    [Header("Spawn Points & Enemies")]
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private Enemy[] enemyTypes;
    [SerializeField] private Enemy[] bossTypes;

    [Header("Spawn Timing")]
    public float initialSpawnCooldown = 5f;  // Initial delay between spawns
    public float minSpawnCooldown = 0.05f;   // Minimum spawn time
    public float spawnAcceleration = 0.1f;   // Rate at which spawns speed up
    public float bossSpawnInterval = 30f;    // Time interval for boss spawns

    private float currentSpawnCooldown;
    private float elapsedTime = 0f;

    private void Start()
    {
        currentSpawnCooldown = initialSpawnCooldown;
        StartCoroutine(BossSpawnRoutine());
        StartCoroutine(EnemySpawnRoutine());
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    private IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            if (GameManager.instance.numOfEnemies < GameManager.instance.currentMaxNumOfEnemies)
            {
                SpawnEnemy();
            }

            // Dynamically decrease spawn cooldown over time, but cap at minSpawnCooldown
            currentSpawnCooldown = Mathf.Max(initialSpawnCooldown * Mathf.Exp(-spawnAcceleration * elapsedTime), minSpawnCooldown);

            Debug.Log($"[Time {elapsedTime:F2}s] Next enemy in {currentSpawnCooldown:F2} seconds.");

            yield return new WaitForSeconds(currentSpawnCooldown);
        }
    }

    private IEnumerator BossSpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(bossSpawnInterval);
            SpawnBoss();
        }
    }

    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemyTypes.Length);

        Instantiate(enemyTypes[enemyIndex], spawnPoints[spawnIndex].transform);
        GameManager.instance.numOfEnemies++;

        Debug.Log($"Enemy Spawned at {elapsedTime:F2}s. Total: {GameManager.instance.numOfEnemies}");
    }

    private void SpawnBoss()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int bossIndex = Random.Range(0, bossTypes.Length);

        Instantiate(bossTypes[bossIndex], spawnPoints[spawnIndex].transform);
        Debug.Log($"BOSS Spawned at {elapsedTime:F2}s!");
    }
}
