using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    // PatrollingEnemy.cs can use this variable, because it's child of Enemy.cs. I don't even need to connect them like "private Enemy enemy;" , "GetComponent<Enemy>();". I DONT need those codes!!!

    void Start()
    {

    }

}
