using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : IMover
{
    float _moveSpeed = 3f;
    IEntityController _controller;
    public Mover(IEntityController controller, float moveSpeed)
    {
        _controller = controller;
        _moveSpeed = moveSpeed;
    }
    public void Tick(float horizontal)
    {
        if (horizontal == 0) return;

        _controller.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);
    }
}
