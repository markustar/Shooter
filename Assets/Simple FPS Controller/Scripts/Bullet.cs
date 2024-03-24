using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 20f;
    public float bulletForce = 1000.0f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet has collided with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the Health component of the enemy (assuming you attached the Health script to the enemy)
            Health enemyHealth = collision.gameObject.GetComponent<Health>();

            // If the enemy has a Health component, apply damage
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);
            }

            // Destroy the bullet after colliding with the enemy
            Destroy(this.gameObject);
        }
        else if (!collision.gameObject.CompareTag("Weapon"))
        {
            
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        // Apply initial force to the bullet in the forward direction
        Rigidbody bulletRb = GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);
        }

        // Destroy the bullet after 2 seconds even if it doesn't hit anything
        Destroy(gameObject, 2.0f);
    }
}
