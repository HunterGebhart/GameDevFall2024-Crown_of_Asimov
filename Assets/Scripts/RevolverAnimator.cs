using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/* 
 * A class that defines the behavior of the player's revolver and which animations play at any given time
 */
public class RevolverAnimation : MonoBehaviour
{
    [Header("Animators")]
    [SerializeField] public Animator revolverAnimator;

    //Play the shooting animation if no other animation is playing
    public void ShootRevolver()
    {
        if(revolverAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleRevolver"))
        {
            revolverAnimator.SetTrigger("PressShoot");
        }
    }

    //Play the reload animation if no other animation is playing
    public void ReloadRevolver()
    {
        if(revolverAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleRevolver"))
        {
            revolverAnimator.SetTrigger("PressReload");
        }
    }
}
