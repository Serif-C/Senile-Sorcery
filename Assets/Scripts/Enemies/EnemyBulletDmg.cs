using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDmg : MonoBehaviour
{
    public Enemy enemy;

    private Vector2 bulletStarPoint;
    private Vector2 bulletCurrentPosition;

    private void Start()
    {
        bulletStarPoint = gameObject.transform.position;
    }

    private void Update()
    {
        bulletCurrentPosition = gameObject.transform.position;
        DeleteBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
        if(player != null)
        {
            player.TakeDmg(enemy);
            Destroy(gameObject);
        }
    }

    void DeleteBullet()
    {
        if(Vector2.Distance(bulletStarPoint, bulletCurrentPosition) > 50)
        {
            Destroy(gameObject);
        }
    }
}
