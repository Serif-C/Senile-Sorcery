using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform projPoint;
    public GameObject enemyBulletPrefab;
    public Transform playerTransform;
    public float bulletForce = 1f; // used to adjust enemy projectile speed

    // Enemy Shoot CD
    public float fireRate = 0f;
    private float nextFireTime = 2.0f;

    // Bullet Direction  = Player Vector2 - FireLocation Vector2
    Vector2 playerPosition;
    Vector2 projPointPosition;
    Vector2 bulletDirection;

    private void Start()
    {
        // Get player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        playerPosition = new Vector2(playerTransform.position.x, playerTransform.position.y);
        projPointPosition = new Vector2(projPoint.position.x, projPoint.position.y);
        bulletDirection = playerPosition - projPointPosition;

        if (fireRate <= 0f)
        {
            Shoot();
            fireRate = nextFireTime;
        }
        else
        {
            fireRate -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, projPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletDirection * bulletForce, ForceMode2D.Impulse);
    }
}
