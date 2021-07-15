using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour,IAttacker
{
    [SerializeField]
    int damage = 1;

    public int Damage=> damage;

    public virtual void Attack(ITakeHit takeHit)
    {
        takeHit.TakeHit(this);
    }
}
