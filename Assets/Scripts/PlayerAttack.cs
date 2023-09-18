using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage;
    private int enemyLayer;

    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            Debug.Log("Hit enemy!");
        }
    }
}
