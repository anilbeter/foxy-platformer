using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    private PlayerMoveControls pMC;
    private GatherInput gI;
    private Animator anim;

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
            //

            // conditions are met: start attack
            // start animation, set "attackStarted" to true
        }
    }
}
