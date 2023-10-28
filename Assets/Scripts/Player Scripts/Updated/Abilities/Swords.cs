using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : MonoBehaviour
{
    public Transform playerTransform;

    private void FixedUpdate()
    {
        // Should add a cooldown to dmg procs
        SwordDmgOnContact();
    }

    private void SwordDmgOnContact()
    {
        
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, GameManager.instance.swordDamageRadius);

        for(int i = 0; i < enemyColliders.Length; i++)
        {
            Collider2D collider = enemyColliders[i];
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (collider.gameObject.CompareTag("Enemy"))
            {
                enemy.EnemyTakeDmg(GameManager.instance.swordDmg);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Set the Gizmo color to red (you can change it if needed)
        Gizmos.DrawWireSphere(transform.position, GameManager.instance.swordDamageRadius); // Draw a wire sphere with the specified radius at the current object's position
    }
}

