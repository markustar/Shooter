using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public HealthBar healthBar;
    public void TakeDamage(float damage) 
    {
        healthBar.health -= damage;
    }
}
