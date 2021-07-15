using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Mobile_Input : IPlayerInput
{
    public float Horizontal => CrossPlatformInputManager.GetAxis("Horizontal");

    public float Vertical => CrossPlatformInputManager.GetAxis("Vertical");

    public bool JumpButtonDown => CrossPlatformInputManager.GetButtonDown("Jump");

    public bool AttackButtonDown => CrossPlatformInputManager.GetButtonDown("Fire1");
}
