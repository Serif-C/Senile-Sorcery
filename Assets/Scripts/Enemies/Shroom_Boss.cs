using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom_Boss : MonoBehaviour
{
    // THE SHROOM BOSS CANNOT BE DAMAGED ON ITS HEAD
    [Header("Boss Misc")]
    public float expReward = 1500f;
    public Enemy enemy;
    public bool hasGivenExp = false;

    [Header("Boss Projectiles")]
    public GameObject projectilePrefab;
    public float bulletForce = 2f;
    public int numOfProjectiles = 12;
    public float fireRate = 0f;
    public float nextFireTime = 2.0f;
    public int startAngle = 0;
    public int projectileSpreadIncrement = 30;




    private void Start()
    {
        // Melee in terms of sharing the same movement as a normal melee enemy
        // Can still use long-range/AOE attacks
        enemy.isEnemyMelee = true; 
    }

    private void Update()
    {
        if (enemy.isDead == true && !hasGivenExp)
        {
            addEXP(expReward);
            hasGivenExp = true;
            StartCoroutine(DestroyAfterDelay());
        }

        if (fireRate <= 0f)
        {
            enemy.animator.SetBool("isRangeAttackCD", true);
            LongRangeBossAttack();
            fireRate = nextFireTime;
        }
        else
        {
            fireRate -= Time.deltaTime;
            enemy.animator.SetBool("isRangeAttackCD", false);
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

    private void BossAttackPattern()
    {
        // If in melee range call MeleeBossAttack()
        // If slightly outside melee range call MidRangeBossAttack()
        // If far away call LongRangeBossAttack()LongRangeBossAttack()
        // If in melee or mid range, if MeleeBossAttack() and MidRangeBossAttack() are in cd call AreaAttack()
    }

    private void MeleeBossAttack()
    {

    }

    private void MidRangeBossAttack()
    {

    }

    private void LongRangeBossAttack()
    {
        // CODE THIS!!!! Perform a bullet hell attack!!!!
        for (int i = 0; i < numOfProjectiles; i++)
        {
            float angleProj = startAngle + i * projectileSpreadIncrement;
            Vector2 direction = Quaternion.Euler(0, 0, angleProj) * transform.up;

            GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
        }
        
    }

    private void AreaAttack()
    {

    }
}
