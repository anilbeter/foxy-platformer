using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed;

    private GatherInput gI;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gI = GetComponent<GatherInput>();
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new(speed * gI.valueX, rb.velocity.y);
    }
}
