using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    // Reference of Player rigidBody
    [SerializeField] private Rigidbody2D playerRb;

    // Reference to HealthBar component
    public HealthBar healthBar;

    // Reference to ExperienceBar component
    public ExperienceBar expBar;

    public Coins coins;
    private void Start()
    {
        // Set current health equal to max health on start 
        GameManager.instance.currentHealth = GameManager.instance.maxHealth;
        healthBar.SetMaxHealth(GameManager.instance.maxHealth);
        expBar.SetMaxEXP(GameManager.instance.expNeeded);

        // Testing some codes here //
        //GameManager.instance.currentElementType = GameManager.Elements.Fire;
    }

    private void FixedUpdate()
    {
        GainExp();

        // Ensure shoot rate never becomes faster than the limit
        // Rounds up/down startShootCoolDown to shootRateLimit
        if (GameManager.instance.startShootCoolDown <= GameManager.instance.shootRateLimit)
        {
            GameManager.instance.startShootCoolDown = GameManager.instance.shootRateLimit;
        }

        GainHealth();
        LevelUp();
        PickUpCollectibles();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player takes damage on enemy collision or enemy attack collision
        if(collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            TakeDmg(enemy);
        }
    }

    public void TakeDmg(Enemy enemy)
    {
        float armour = GameManager.instance.armour;
        if(armour <= enemy.dmg)
        {
            GameManager.instance.currentHealth -= (enemy.dmg - armour);
        }
        else
        {
            // Take 0 damage when player armour is higher than enemy damage
            GameManager.instance.currentHealth -= 0;
        }
        healthBar.SetHealth(GameManager.instance.currentHealth);
    }

    public void GainHealth()
    {
        healthBar.SetMaxHealth(GameManager.instance.maxHealth);
        healthBar.SetHealth(GameManager.instance.currentHealth);
    }

    void Die()
    {
        if(GameManager.instance.currentHealth <= 0)
        {
            //play death animation
            //gameover screen
        }
    }

    public void GainExp()
    {
        expBar.SetEXP(GameManager.instance.currentExp);
    }

    // Changes game state from Gameplay to LevelUp 
    // LevelUp Screen pops up where upgrades can be chosen
    // Exp goes back to 0 and exp for next levelup increases
    public void LevelUp()
    {
        if(GameManager.instance.currentExp >= GameManager.instance.expNeeded)
        {
            GameManager.instance.Shuffle();
            GameManager.instance.previousState = GameManager.instance.currentState;
            GameManager.instance.currentState = GameManager.GameState.LevelUp;

            GameManager.instance.lvl += 1;
            GameManager.instance.currentExp = 0;
            GameManager.instance.expNeeded *= 1.8f;
            expBar.SetMaxEXP(GameManager.instance.expNeeded);
        }
    }

    private void PickUpCollectibles()
    {
        Collider2D[] collectibleCollider = Physics2D.OverlapCircleAll(transform.position, GameManager.instance.collectRange);

        for(int i = 0; i < collectibleCollider.Length; i++)
        {
            Collider2D collider = collectibleCollider[i];
            if(collider.CompareTag("Collectible"))
            {
                // ????Should suck the coin towards player, destroy it when it gets close enough and add it to player's coin counter????
                Destroy(collider.gameObject);
                coins.numOfCoins += 1;
            }
        }
    }
}
