using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] Enemy[] enemy;
    [SerializeField] Enemy[] bosses;


    private float spawnCD;   //Cooldown between each spawn
    public float startSpawnCD;  //Start the cooldown back up
    public float spawnRate;  //Decrease spawn rate the longer the game goes 
    public float maxSpawnRate;
    public float spawnRateDecay = 0.1f;
    public int maxEnemies;

    private float elapsedTime = 0f;

    private void Start()
    {
        spawnCD = startSpawnCD;
        StartCoroutine(SpawnBoss(30));
    }

    private void Update()
    {
        if (GameManager.instance.numOfEnemies < GameManager.instance.currentMaxNumOfEnemies)
        {
            if (spawnCD <= 0f)
            {
                SpawnEnemy();
                spawnCD = startSpawnCD;

                // decrease spawn cd
                if (startSpawnCD > maxSpawnRate)
                {
                    startSpawnCD -= spawnRate;
                    startSpawnCD = CalculateSpawnCooldown();
                    Debug.Log($"[{elapsedTime:F2}s] Enemy spawned! spawnCD: {spawnCD}, startSpawnCD: {startSpawnCD}");
                }
                //// keep startSpawnCD equal to spawn rate when it has reach maxSpawnRate
                //else
                //{
                //    startSpawnCD = spawnRate;
                //}
            }
            else
            {
                spawnCD -= Time.deltaTime;
            }
        }

        for(int i = 0; i < bosses.Length; i++)
        {
            int numOfDeadBosses = 0;
            if(bosses[i].gameObject.GetComponent<Enemy>().isDead == true)
            {
                numOfDeadBosses++;
                if(numOfDeadBosses == bosses.Length)
                {
                    gameObject.SetActive(false);
                    Debug.Log("Boss has been killed, no longer spawning enemies");
                }
            }
        }
    }

    public void SpawnEnemy()
    {
        int rand = Random.Range(0, spawnPoints.Length);
        int enemyRand = Random.Range(0, enemy.Length);

        if(GameManager.instance.minutes < 1)
        {
            Instantiate(enemy[0], spawnPoints[rand].transform);
            //GameManager.instance.numOfEnemies++;
        }
        else
        {
            Instantiate(enemy[enemyRand], spawnPoints[rand].transform);
            //GameManager.instance.numOfEnemies++;
        }
        GameManager.instance.numOfEnemies++;
    }

    private float CalculateSpawnCooldown()
    {
        // Formula: startSpawnCD * exp(-decay * elapsedTime)
        float newSpawnCD = startSpawnCD * Mathf.Exp(-spawnRateDecay * elapsedTime);
        return Mathf.Max(newSpawnCD, maxSpawnRate); // Ensure it never goes below 0.05s
    }

    private void TestingBossSpawn()
    {
        // Set Initial and Current Max Num of Enemies accordingly when testing BOSS!!!

        Instantiate(enemy[2], spawnPoints[2].transform);
        GameManager.instance.numOfEnemies++;
    }

    private IEnumerator SpawnBoss(float delay)
    {
        yield return new WaitForSeconds(delay);

        int rand = Random.Range(0, spawnPoints.Length);
        int randBoss = Random.Range(0, bosses.Length);
        Instantiate(bosses[randBoss], spawnPoints[rand].transform);

        Debug.Log("Boss spawned after waiting for " + GameManager.instance.seconds + " seconds.");
    }
}
