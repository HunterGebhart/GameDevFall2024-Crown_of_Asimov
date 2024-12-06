using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    private Transform currTarget;
    public string pointA_Name;
    public string pointB_Name;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        targetA = GameObject.Find(pointA_Name).transform;
        targetB = GameObject.Find(pointB_Name).transform;
        currTarget = targetB;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distanceToA = Vector3.Distance(transform.position, targetA.position);
        float distanceToB = Vector3.Distance(transform.position, targetB.position);

        if(distanceToB == 0f)
        {
            Debug.Log("Destination Reached!");
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, currTarget.position, speed * Time.deltaTime);
    }
}
