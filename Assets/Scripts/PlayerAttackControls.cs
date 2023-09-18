using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    private PlayerMoveControls pMC;
    private GatherInput gI;
    private Animator anim;

    public PolygonCollider2D polyCol;

    public bool attackStarted = false;

    void Start()
    {
        pMC = GetComponent<PlayerMoveControls>();
        gI = GetComponent<GatherInput>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (gI.tryAttack)
        {
            // check conditions
            // (if we already attacking or we don't have control or knocback is true: then return and don't attack)
            if (attackStarted || !pMC.hasControl || pMC.knockBack)
                return;

            // conditions are met: start attack
            // start animation, set "attackStarted" to true
            anim.SetBool("Attack", true);
            attackStarted = true;
        }
    }

    public void ActivateAttack()
    {
        polyCol.enabled = true;
    }

    public void ResetAttack()
    {
        // reset the animation and bool variables
        anim.SetBool("Attack", false);
        gI.tryAttack = false;
        // FIX only one attack even player holds attack key

        attackStarted = false;
        polyCol.enabled = false;
    }
}
