using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDmg : MonoBehaviour
{
    private float playerBulletDmg;

    private Vector2 bulletStartPoint;
    private Vector2 bulletPosition;
    private int numOfEnemyPierced = 0;

    public GameObject explosionPrefab;
    public GameObject normalBulletParticle;

    private void Start()
    {
        bulletStartPoint = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        playerBulletDmg = GameManager.instance.dmg;

        bulletPosition = gameObject.transform.position;
        DeleteBullet();
    }


    // Enemy recieves dmg from player's bullet //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            Instantiate(normalBulletParticle, transform.position, Quaternion.identity);
            enemy.EnemyTakeDmg(playerBulletDmg);

            // Might be a good idea to use switch statements for these!
            if(GameManager.instance.canPierce == false)
            {
                if (GameManager.instance.currentElementType == GameManager.Elements.Fire)
                {
                    // explode upon colliding with an enemy, damages everything in the radius
                    // turns off pierce cuz thats probably too strong

                    fireExplosion();
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            else if(numOfEnemyPierced <= GameManager.instance.numOfPierce)
            {
                numOfEnemyPierced++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void DeleteBullet()
    {
        if (Vector2.Distance(bulletPosition, bulletStartPoint) > 50)
        {
            Destroy(gameObject);
        }
    }

    // Should have screen shake on explode, screen shakes more aggressively the more enemies are caught in explosion
    private void fireExplosion()
    {
        float explodeDmg = (GameManager.instance.dmg * GameManager.instance.explosionDmgMultiplier);
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, GameManager.instance.explosionRadius);

        for(int i = 0; i < enemyColliders.Length; i++)
        {
            Collider2D collider = enemyColliders[i];
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if(collider.gameObject.CompareTag("Enemy"))
            {
                enemy.EnemyHitByExplosion(explodeDmg);
            }
        }
    }
}
