using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public bool canTakeDamage = true;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            health -= damage;
            // play hurt animation

            if (health <= 0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponentInParent<GatherInput>().DisableControls();
                Debug.Log("Player is dead :(");
            }

            StartCoroutine(DamagePrevention());
        }
    }

    // Idea -> I want to delay/wait after take damage until take next damage. I should use Coroutines for add delay
    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        // When player takes damage, will wait 0.15 seconds to take next damage 
        yield return new WaitForSeconds(0.15f);
        // Player is still alive?
        if (health > 0)
        {
            // after 0.15 seconds later, again player can take damage.
            canTakeDamage = true;
        }
        else
        {
            // play death animation
        }
    }
}
