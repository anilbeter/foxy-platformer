using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public bool canTakeDamage = true;

    private Animator anim;
    private PlayerMoveControls playerMove;

    private Image healthUI;

    void Start()
    {
        healthUI = GameObject.FindGameObjectWithTag("HealthUI").GetComponent<Image>();
        anim = GetComponentInParent<Animator>();
        health = maxHealth;
        playerMove = GetComponentInParent<PlayerMoveControls>();
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            health -= damage;
            // play hurt animation
            anim.SetBool("Damage", true);

            playerMove.hasControl = false;
            UpdateHealthUI();
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
            // after 0.15s, hurt animation will be false
            anim.SetBool("Damage", false);

            playerMove.hasControl = true;
        }
        else
        {
            // play death animation
            anim.SetBool("Death", true);
        }
    }

    public void UpdateHealthUI()
    {
        // fillAmount uses values between 0 and 1. So I need to divide to maxHealth. My values will be = 1, 0.8, 0.6, 0.4, 0.2, and 0
        healthUI.fillAmount = health / maxHealth;
    }
}
