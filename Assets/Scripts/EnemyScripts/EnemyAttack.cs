using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage;
    protected PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stats"))
        {
            playerStats = collision.GetComponent<PlayerStats>();
            playerStats.TakeDamage(damage);

            SpecialAttack();
        }
    }

    // To implement different behaviours to child classes, we use VIRTUAL function
    // virtual function should be in PARENT class
    // [IMPORTANT] It's virtual because -> we can OVERWRITE on this function in child classes
    public virtual void SpecialAttack()
    {

    }
}
