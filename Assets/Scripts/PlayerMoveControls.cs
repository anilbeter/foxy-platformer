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
    public int additionalJumps;
    private int resetJumpsNumber;

    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    public Transform rightPoint;
    public bool touchingGround = true;

    private bool knockBack = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gI = GetComponent<GatherInput>();
        anim = GetComponent<Animator>();

        resetJumpsNumber = additionalJumps;
    }


    void Update()
    {
        SetAnimatorValues();
    }

    private void FixedUpdate()
    {
        CheckStatus();
        if (knockBack)
            return;
        // if knockBack true, then player won't able to move or jump
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
            else if (additionalJumps > 0)
            {
                rb.velocity = new(gI.valueX * speed, jumpForce);
                additionalJumps--;
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

        anim.SetFloat("verticalSpeed", rb.velocity.y);
        anim.SetBool("Grounded", touchingGround);
    }

    private void CheckStatus()
    {
        RaycastHit2D leftCheck = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheck = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);
        if (leftCheck || rightCheck)
        {
            touchingGround = true;
            additionalJumps = resetJumpsNumber;
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

    public IEnumerator KnockBack(float forceX, float forceY, float duration, Transform otherObject)
    {
        int knockBackDirection;
        // check if player is to the left of spike (otherObject -> spike)
        if (transform.position.x < otherObject.position.x)
            knockBackDirection = -1;
        // since player is to left of spike, then it should knock back player to the left
        else
            knockBackDirection = 1;

        knockBack = true;

        // Reset forces on the player
        rb.velocity = Vector2.zero;

        Vector2 theForce = new(knockBackDirection * forceX, forceY);
        // Now add this force to the rigidboy with AddForce function (built-in)
        rb.AddForce(theForce, ForceMode2D.Impulse);

        // How much second delay should be applied for knocback method execution?
        yield return new WaitForSeconds(duration);

        // After knocback, the knocback effect should be stopped
        knockBack = false;
        // again we should reset forces on the player
        rb.velocity = Vector2.zero;

    }
}
