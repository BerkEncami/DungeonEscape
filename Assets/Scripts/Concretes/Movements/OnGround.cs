
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour,IOnGround
{
    [SerializeField]
    Transform[] transforms;
    [SerializeField]
    float maxDistance = 0.3f;
    [SerializeField]
    LayerMask layerMask;

    bool _isGround;
    public bool IsGround => _isGround;

  

    private void Update()
    {
        foreach(Transform foots in transforms)
        {
            CheckIfFootsOnGround(foots);
          
            if (_isGround) break; 
        }
    }

    private void CheckIfFootsOnGround(Transform foots)
    {
        RaycastHit2D hit = Physics2D.Raycast(foots.position, foots.transform.forward, maxDistance, layerMask);
        Debug.DrawRay(foots.position, foots.forward * maxDistance, Color.red);
        if(hit.collider != null)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }
}
