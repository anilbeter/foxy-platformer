using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private GatherInput gI;
    private Rigidbody2D rb;
    private Animator anim;

    private int direction = 1;

    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    public Transform rightPoint;
    public bool touchingGround = true;

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
        CheckStatus();
        Move();
        Jump();
    }

    private void Move()
    {
        Flip();
        rb.velocity = new(speed * gI.valueX, rb.velocity.y);
    }

    private void Jump()
    {
        if (gI.jumpInput)
        {
            if (touchingGround)
            {
                rb.velocity = new(gI.valueX * speed, jumpForce);
            }
        }
        gI.jumpInput = false;
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

    private void CheckStatus()
    {
        RaycastHit2D leftCheck = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheck = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);
        if (leftCheck || rightCheck)
        {
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }
        // SeeRays(leftCheck, rightCheck);
    }

    // private void SeeRays(RaycastHit2D leftCheckHit, RaycastHit2D rightCheckHit)
    // {
    //     Color color1 = leftCheckHit ? Color.red : Color.green;
    //     Debug.DrawRay(leftPoint.position, Vector2.down * rayLength, color1);

    //     Color color2 = rightCheckHit ? Color.red : Color.green;
    //     Debug.DrawRay(rightPoint.position, Vector2.down * rayLength, color2);
    // }
}
