using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class that plays an animation based on animator and the animation clip's name
 */
public class TriggerAnimation : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("Animation Clip")]
    [SerializeField] public string animationClip;

    //Play the animation
    public void PlayAnimation()
    {
        animator.Play(animationClip);
    }
}
