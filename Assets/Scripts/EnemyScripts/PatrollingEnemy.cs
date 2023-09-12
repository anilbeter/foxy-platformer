using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
// Now Enemy.cs is parent class, PatrollingEnemy.cs is child class
{
    public float speed;
    private int direction = -1;

    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerToCheck;

    private bool detectGround;
    private bool detectWall;

    public float radius;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Flip();
        rb.velocity = new(direction * speed, rb.velocity.y);
    }

    private void Flip()
    {
        detectGround = Physics2D.OverlapCircle(groundCheck.position, radius, layerToCheck);
        // this will return true or false depending on ground inside or outside of the circle

        detectWall = Physics2D.OverlapCircle(wallCheck.position, radius, layerToCheck);

        if (detectWall || !detectGround)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }

    // for see circles that I created above in Flip() method
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }
}
