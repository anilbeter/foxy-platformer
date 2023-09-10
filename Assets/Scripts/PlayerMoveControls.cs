using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed;

    private GatherInput gI;
    private Rigidbody2D rb;
    private Animator anim;

    private int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gI = GetComponent<GatherInput>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        SetAnimatorValues();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Flip();
        rb.velocity = new(speed * gI.valueX, rb.velocity.y);
    }

    private void Flip()
    {
        if (gI.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }

    private void SetAnimatorValues()
    {
        // I used Mathf.Abs cuz when player moves to the left, rb.velocity.x less than zero (negative). And I setted Move->Idle condition to less than 0.01f. So when player moves to the left, animation will be Idle. I dont want that. To do so I use Mathf.Abs to prevent Idle animation when player moves to the left.
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}
