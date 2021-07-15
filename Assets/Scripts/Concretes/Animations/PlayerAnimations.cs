using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations :IAnimation
{
    Animator _animator;
    public PlayerAnimations (Animator animator)
    {
        _animator = animator;
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("attack");
    }

    public void DeadAnimation()
    {
        _animator.SetTrigger("dead");
    }

    public void JumpAnimation(bool IsJump)
    {
        if (_animator.GetBool("IsJump").Equals(IsJump)) return;

        _animator.SetBool("IsJump", IsJump);
    }

    public void MoveAnimation(float MoveSpeed)
    {
          
        _animator.SetFloat("MoveSpeed" , Mathf.Abs(MoveSpeed)); 
    }

    public void TakeHitAnimation()
    {
        _animator.SetTrigger("takeHit");
    }
}
