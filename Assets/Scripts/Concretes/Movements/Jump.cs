using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump 
{
    float jumpForce = 240f;
    Rigidbody2D _rb;
    public Jump(Rigidbody2D rb)
    {
        _rb = rb;
    }
   
    public void TickWithFixedUpdate()
    {
        _rb.AddForce(Vector2.up * jumpForce);
        _rb.velocity = Vector2.zero;
    }
}
