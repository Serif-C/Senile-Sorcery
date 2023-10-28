using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimes : MonoBehaviour
{
    // Exp Reward by slime enemies
    // Item Drops by slime enemies
    // Dmg Multiplier (to be used by Enemy script)
    // Amour Multiplier (to be used by Enemy script)

    public float expReward = 500f;

    // Reference to Enemy component
    public Enemy enemy;

    public bool hasGivenExp = false;

    private void Start()
    {
        enemy.isEnemyMelee = true;
    }

    private void Update()
    {
        if(enemy.isDead == true && !hasGivenExp)
        {
            addEXP(expReward);
            hasGivenExp = true;
            StartCoroutine(DestroyAfterDelay());
        }
    }

    // should drop exp shards instead
    void addEXP(float exp)
    {
        GameManager.instance.currentExp += exp;
    }

    private IEnumerator DestroyAfterDelay()
    {
        // Wait for a short delay before destroying the enemy object
        yield return 0.02f;
        GameManager.instance.numOfEnemies -= 1;
        Destroy(enemy.gameObject);
    }
}
