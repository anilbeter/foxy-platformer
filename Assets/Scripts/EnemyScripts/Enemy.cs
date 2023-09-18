using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    // PatrollingEnemy.cs can use this variable, because it's child of Enemy.cs. I don't even need to connect them like "private Enemy enemy;" , "GetComponent<Enemy>();". I DONT need those codes!!!
    // NOTE: inherit variables must be public or protected
    // protected -> 1) I can't see them in inspector (just like private variables)
    // 2) other classes (except child classes) neither cant see nor use protected variables
    // 3) visible just to parent and child classes

    protected Rigidbody2D rb;
    protected Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // enemy death animation
            Destroy(gameObject);
        }
    }

}
