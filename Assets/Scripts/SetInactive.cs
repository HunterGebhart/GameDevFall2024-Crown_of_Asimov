using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour
{
    [SerializeField] public GameObject setInactiveHolder;

    private bool inCollider;

    // Start is called before the first frame update
    void Start()
    {
        inCollider = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inCollider)
        {
            Debug.Log("E key Detected!");
            setInactiveHolder.SetActive(false);
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
