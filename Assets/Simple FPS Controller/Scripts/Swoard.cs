using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swoard : MonoBehaviour
{
    public float attackDamage = 20f;
    public float attackRange = 1f;
    public LayerMask enemyLayer;


    private void Update()
    {
        // Check for player input to perform the sword attack
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        // Play the attack animation

        // Perform the melee attack and deal damage to enemies within the attack range
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            // Check if the object has a health component
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                // Deal damage to the enemy
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    // Draw a gizmo to visualize the attack range in the Unity editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
