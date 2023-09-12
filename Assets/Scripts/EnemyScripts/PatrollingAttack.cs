using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAttack : EnemyAttack
{
  PlayerMoveControls playerMove;
  public float forceX;
  public float forceY;
  public float duration;

  // Now I want the override virtual function that I created on parent class
  public override void SpecialAttack()
  {
    base.SpecialAttack();

    // playerStates comes from parent (EnemyAttack)
    playerMove = playerStats.GetComponentInParent<PlayerMoveControls>();
    StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform.parent));
    // I used transform.parent because PatrolligAttacks child of EnemyAttack, I need parents transform
  }
}
