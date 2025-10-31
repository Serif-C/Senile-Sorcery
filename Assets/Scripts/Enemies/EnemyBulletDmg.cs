using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDmg : MonoBehaviour
{
    public Enemy enemy;

    private Vector2 bulletStarPoint;
    private Vector2 bulletCurrentPosition;

    public GameObject particle;
    public float bulletLifeTime = 2f;
    private float timeElapsed = 0f;

    private void Start()
    {
        bulletStarPoint = gameObject.transform.position;
    }

    private void Update()
    {
        bulletCurrentPosition = gameObject.transform.position;
        timeElapsed += Time.deltaTime;
        DeleteBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
        if(player != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            player.TakeDmg(enemy);
            Destroy(gameObject);
        }
    }

    void DeleteBullet()
    {
        if(Vector2.Distance(bulletStarPoint, bulletCurrentPosition) > 50 || timeElapsed >= bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }
}
