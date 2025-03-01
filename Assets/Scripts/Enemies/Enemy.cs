using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5f;
    private float moveBack;
    public Animator animator;

    private Vector2 enemyPosition;
    private Transform playerTransform;

    // Enemy Base Stats (should be modified by inheriting types of enemies)
    public float maxHealth = 20f;
    public float currentHealth;
    public float dmg = 10f;
    public float armour = 10;
    public bool isDead = false;

    // Stats used by long-range enemies
    public float stoppingDistance = 5.0f;
    public float retreatDistance = 2.0f;

    public HealthBar enemyHealthBar;

    // Enemy attack range type
    public bool isEnemyMelee;

    public GameObject damagePopUpPrefab;
    public GameObject coinPrefab;
    public GameObject deathFX;
    public AudioSource dmgSFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        // Set enemy initial Health Bar to value of maxHealth
        enemyHealthBar.SetMaxHealth(maxHealth);

        // Find the player GameObject with the "Player" tag during initialization.
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Move Back (for range enemies only)
        moveBack = (moveSpeed / 2f);

    }

    private void Update()
    {
        // Get enemy movement direction
        enemyPosition = rb.position;
        float enemyDirectionX = playerTransform.position.x - enemyPosition.x;
        float enemyDirectionY = playerTransform.position.y - enemyPosition.y;

        // Set enemy animation depending on what direction they are going
        animator.SetFloat("Speed", enemyPosition.magnitude);
        animator.SetFloat("SpeedX", enemyDirectionX);
        animator.SetFloat("SpeedY", enemyDirectionY);

        // If enemy is melee, chase the player until they make contact
        if (isEnemyMelee == true)
        {
            DoEnemyThings();
        }
        // if the enemy is range, get within a certain range of player and attempts to always be within said range
        else if(isEnemyMelee != true)
        {
            DoRangedEnemyThings();
        }

        enemyDie();
    }

    void DoEnemyThings()
    {
        // when player is within a certain radius, chase them
        rb.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
    }

    void DoRangedEnemyThings()
    {
        // Move towards the player
        if (Vector2.Distance(transform.position, playerTransform.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
        // Move away from the player if too close
        else if (Vector2.Distance(transform.position, playerTransform.position) < stoppingDistance
            && Vector2.Distance(transform.position, playerTransform.position) > retreatDistance)
        {
            transform.position = this.transform.position * moveBack;
        }
        // Retreat from the player
        else if (Vector2.Distance(transform.position, playerTransform.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, -moveSpeed * Time.deltaTime);
        }
    }

    public void EnemyTakeDmg(float dmg)
    {
        if (dmg >= armour)
        {
            dmg -= armour;
        }
        else
        {
            dmg = 0;
        }
        currentHealth -= dmg;
        GameManager.instance.dmgDealt = dmg;
        enemyHealthBar.SetHealth(currentHealth);
        Instantiate(damagePopUpPrefab, transform.position, Quaternion.identity);
        dmgSFX.Play();
    }

    public void EnemyHitByExplosion(float dmg)
    {
        currentHealth -= dmg;
        GameManager.instance.dmgDealt = dmg;
        enemyHealthBar.SetHealth(currentHealth);
        Instantiate(damagePopUpPrefab, transform.position, Quaternion.identity);
    }

    public void enemyDie()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
            // destroy this game object
            isDead = true;
            int random = Random.Range(1, 11);
            if(random == 1)
            {
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
