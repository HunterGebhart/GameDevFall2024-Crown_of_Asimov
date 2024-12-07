using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * A class that defines the scene transition
 */
public class Transition : MonoBehaviour
{
    [Header("Animators")]
    [SerializeField] Animator animator;

    [Header("Attributes")]
    [SerializeField] float transitionDelayTime = 1.0f;

    //Find game objects
    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    //Start the coroutine with the scene name
    public void LoadLevel(string scene)
    {
        StartCoroutine(DelayLoadLevel(scene));
    }

    //Play the transition animation over time then change the scene
    IEnumerator DelayLoadLevel(string scene)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(scene);
    }
}
