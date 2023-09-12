using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Collider2D heartCollider;
    private SpriteRenderer heartSprite;
    public float recoveryHealth;

    void Start()
    {
        heartCollider = GetComponent<Collider2D>();
        heartSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponentInChildren<PlayerStats>();
            playerStats.IncreaseHealth(recoveryHealth);
            heartCollider.enabled = false;
            heartSprite.enabled = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
