using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip :IFlip 
{
    IEntityController _entityController;
   

    public Flip(IEntityController entity)
    {
        _entityController = entity;
    }

   

    public void FlipCharacter(float direction)
    {
        if (direction.Equals(0)) return;

        float mathValue = Mathf.Sign(direction);

        if (mathValue != _entityController.transform.localScale.x)
        {
            _entityController.transform.localScale = new Vector2(mathValue, 1f);
        }
    }
}
