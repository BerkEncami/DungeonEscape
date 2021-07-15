using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker 
{
    void Attack(ITakeHit takeHit);
    int Damage { get;  }
}
