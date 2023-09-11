using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage;

    public float forceX;
    public float forceY;
    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stats"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);

            // GetComponentInParent because spike collides with PlayerStats and PlayerStats child of Player object. So I need parent (Player), because PlayerMoveControls script attachted to the Player object.
            PlayerMoveControls playerMove = collision.GetComponentInParent<PlayerMoveControls>();

            StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform));
        }

    }
}
