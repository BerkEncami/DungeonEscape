using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    IAttacker _attacker;
    private void Awake()
    {
        _attacker = GetComponent<IAttacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        IHealth health = other.GetComponent<IHealth>();
        if(health != null)
        {
            health.TakeHit(_attacker);
        }
    }
}
