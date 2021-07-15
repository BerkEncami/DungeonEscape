using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationImpact : MonoBehaviour
{
    public event System.Action OnImpact;

    public void Impact()
    {
        OnImpact?.Invoke();
    }
}
