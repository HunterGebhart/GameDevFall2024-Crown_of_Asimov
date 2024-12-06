using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] public string animationClip;

    public void PlayAnimation()
    {
        animator.Play(animationClip);
    }
}
