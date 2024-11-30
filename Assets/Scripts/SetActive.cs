using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] public GameObject setActiveHolder;

    [SerializeField] public bool hasAnimation;

    private bool inCollider;
    private bool canPlayAnimation;

    private TriggerAnimation triggerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        inCollider = false;
        canPlayAnimation = true;
        triggerAnimation = GetComponent<TriggerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inCollider)
        {
            setActiveHolder.SetActive(true);
            if(hasAnimation && canPlayAnimation)
            {
                Debug.Log("Playing Animation...");
                canPlayAnimation = false;
                triggerAnimation.PlayAnimation();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player Found!");
            inCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = false;
        }
    }
}
