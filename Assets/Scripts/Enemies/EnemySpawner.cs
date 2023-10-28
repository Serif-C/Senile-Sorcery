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
    private float minTime = 0.5f;
    public int maxEnemies;

    private void Start()
    {
        StartCoroutine(SpawnBoss(30));
    }

    private void Update()
    {
        maxEnemies = GameManager.instance.initialMaxNumOfEnemies + (GameManager.instance.minutes * 50);
        GameManager.instance.currentMaxNumOfEnemies = maxEnemies;
        if (GameManager.instance.numOfEnemies < maxEnemies)
        {
            if (spawnCD <= 0f)
            {
                SpawnEnemy();
                spawnCD = startSpawnCD;

                // decrease spawn cd
                if(startSpawnCD >= maxSpawnRate)
                {
                    startSpawnCD -= spawnRate;
                }
                // keep startSpawnCD equal to spawn rate when it has reach maxSpawnRate
                else
                {
                    startSpawnCD = spawnRate;
                }
                
            }
            else
            {
                spawnCD -= Time.deltaTime;
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
            GameManager.instance.numOfEnemies++;
        }
        /*else if (GameManager.instance.minutes >= 1 && GameManager.instance.minutes < 2)*/ 
        // for when there are more than 2 types of enemies
        else
        {
            Instantiate(enemy[enemyRand], spawnPoints[rand].transform);
            GameManager.instance.numOfEnemies++;
        }

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
