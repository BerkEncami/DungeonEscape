using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation 
{
    void MoveAnimation(float MoveSpeed);
    void JumpAnimation(bool IsJump);

    void AttackAnimation();
    void TakeHitAnimation();
    void DeadAnimation();

}
