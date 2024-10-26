using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathfindingAI : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] Transform player;
    [SerializeField] Transform headLocation;

    private NavMeshAgent agent;

    private EnemyProjectile enemyProjectile;

    private Ray sightRay;

    [Header("AI Attributes")]
    [SerializeField] float activationDistance = 10f;
    [SerializeField] float attackDistance = 10f;
    [SerializeField] float shootingCooldown = 3f;
    [SerializeField] float sightDistance = 100f;

    [Header("Activation Settings")]
    [SerializeField] bool activated = false;
    //[SerializeField] bool triggeredByRoom = false;

    private float startTime = 0;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyProjectile = GetComponent<EnemyProjectile>();
    }

    void Update()
    {
        RaycastHit hit;

        sightRay = new Ray(headLocation.transform.position, player.transform.position - transform.position - new Vector3(0,2,0));

        bool inShootingRange = Vector3.Distance(transform.position, player.position) <= attackDistance;
        bool inActivationRange = Vector3.Distance(transform.position, player.position) <= activationDistance;
    
        if(inActivationRange && Physics.Raycast(sightRay, out hit, sightDistance) && hit.collider.CompareTag("Player"))
        {
            activated = true;
        }

        if(activated)
        {
            if(gameObject.GetComponent<Entity>().enemyManager.GetComponent<EnemyManager>().inCombat != true)
            {
                gameObject.GetComponent<Entity>().enemyManager.GetComponent<EnemyManager>().SetCombat();
            }
            
            if(inShootingRange && Physics.Raycast(sightRay, out hit, sightDistance) && hit.collider.CompareTag("Player"))
            {
                agent.isStopped = true;
                AttackPlayer();
            }

            else
            {
                agent.isStopped = false;
                agent.destination = player.position;
            }

            LookAtPlayer();
        }
    }

    private void LookAtPlayer()
    {
        Vector3 lookPos = player.position - transform.position;

        lookPos.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookPos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void AttackPlayer()
    {
        if(startTime == 0)
        {
            startTime = Time.time;
        }
        if(Time.time > startTime + shootingCooldown)
        {
            enemyProjectile.Shoot();
            startTime = 0;
        }
    }
}
