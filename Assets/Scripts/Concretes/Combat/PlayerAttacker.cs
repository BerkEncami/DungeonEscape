using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : Attacker
{
    [SerializeField]
    Transform AttackDirection;

    [SerializeField]
    float attackRadius = 1f;

    Collider2D[] _attackResults;
    private void Awake()
    {
        _attackResults = new Collider2D[10];
    }

    private void OnEnable()
    {
        GetComponent<AnimationImpact>().OnImpact += HandleImpact;
    }
    private void OnDisable()
    {
        GetComponent<AnimationImpact>().OnImpact -= HandleImpact;
    }
    private void HandleImpact()
    {
       int hitCount= Physics2D.OverlapCircleNonAlloc(AttackDirection.position + AttackDirection.forward, attackRadius, _attackResults);

        for(int i=0; i < hitCount; i++)
        {
            ITakeHit takeHit = _attackResults[i].GetComponent<ITakeHit>();

            if(takeHit != null)
            {
                Attack(takeHit);
            }
        }

    }

    private void OnDrawGizmos()
    {
        OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackDirection.position + AttackDirection.forward, attackRadius);
    }
}
