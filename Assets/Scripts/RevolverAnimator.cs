using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RevolverAnimation : MonoBehaviour
{
    [SerializeField] public Animator revolverAnimator;

    public void ShootRevolver()
    {
        if(revolverAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleRevolver"))
        {
            revolverAnimator.SetTrigger("PressShoot");
        }
    }

    public void ReloadRevolver()
    {
        if(revolverAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleRevolver"))
        {
            revolverAnimator.SetTrigger("PressReload");
        }
    }
}
