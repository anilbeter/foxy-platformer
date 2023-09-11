using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        // play hurt animation

        if (health <= 0)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            Debug.Log("Player is dead :(");
        }
    }
}
