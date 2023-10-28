using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform projSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 25f;
    [SerializeField] private Camera cam;
    [SerializeField] private Vector2 bookPosition;
    [SerializeField] private Transform playerTransform;
    
    // Used in Orbit //
    [SerializeField] private float orbitSpeed = 50f;
    private Vector3 orbitCenter;

    private Vector2 mousePos;
    private Vector2 projSpawnVect2;

    [SerializeField] private Animator animator;

    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player reference not set. Please assign the player GameObject.");
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        // Ensures that the book is always connected to the player even after collision
        /*transform.position = playerTransform.position;*/
        bookPosition = new Vector2(playerTransform.position.x + 0.16f, playerTransform.position.y - 0.68f);
        this.transform.position = bookPosition;

        // Calculate player's position as the orbitCenter //
        orbitCenter = playerTransform.position;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        projSpawnVect2 = new Vector2(projSpawnPoint.position.x, projSpawnPoint.position.y);

        // Automatically shoots at cursor position when shoot is off cooldown
        if(GameManager.instance.shootCoolDown <= 0f)
        {
            ShootBullet();
            GameManager.instance.shootCoolDown = GameManager.instance.startShootCoolDown;
        }
        else
        {
            GameManager.instance.shootCoolDown -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    { 
        Vector2 bulletDirection = mousePos - projSpawnVect2;
        float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    // ADD DESCRIPTION SOON!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    void ShootBullet()
    {
        float startAngle;
        float angleIncrement;
        if (GameManager.instance.projectileCount >= 2)
        {
            startAngle = -GameManager.instance.projectileSpreadAngle / 2.0f;
            angleIncrement = GameManager.instance.projectileSpreadAngle / (GameManager.instance.projectileCount - 1);

            for (int i = 0; i < GameManager.instance.projectileCount; i++)
            {
                float angleProj = startAngle + i * angleIncrement;
                Vector2 direction = Quaternion.Euler(0, 0, angleProj) * projSpawnPoint.up;

                GameObject bullet = Instantiate(bulletPrefab, projSpawnPoint.position, projSpawnPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
                animator.SetBool("IsShooting", true);
            }
        }
        else // if projectile count is 1
        {
            GameObject bullet = Instantiate(bulletPrefab, projSpawnPoint.position, projSpawnPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(projSpawnPoint.up * bulletForce, ForceMode2D.Impulse);
            animator.SetBool("IsShooting", true);
        }
    }

    void Orbit()
    {
        // Calculate the new position based on the orbit.
        Vector3 offset = Quaternion.Euler(0, 0, orbitSpeed * Time.deltaTime) * (transform.position - orbitCenter);
        transform.position = orbitCenter + offset;
    }
}
