using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathfindingAI : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent agent;

    EnemyProjectile enemyProjectile;

    public float activationDistance = 10f;
    public float attackDistance = 10f;
    public float shootingCooldown = 3f;

    public bool activated = false;

    private float startTime = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyProjectile = GetComponent<EnemyProjectile>();
    }

    // Update is called once per frame
    void Update()
    {
        float originalSpeed = agent.speed;
        
        bool inShootingRange = Vector3.Distance(transform.position, player.position) <= attackDistance;
        bool inActivationRange = Vector3.Distance(transform.position, player.position) <= activationDistance;
    
        if(inActivationRange)
        {
            activated = true;
        }
        if(activated)
        {
            if(inShootingRange)
            {
                agent.isStopped = true;
                AttackPlayer();
            }
            else
            {
                agent.isStopped = false;
                Debug.Log("Moving!");
                agent.destination = player.position;
                
            }
        }

        LookAtPlayer();
    }

    void LookAtPlayer()
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
            Debug.Log("StartTime!");
            startTime = Time.time;
        }
        if(Time.time > startTime + shootingCooldown)
        {
            Debug.Log("Shooting!");
            enemyProjectile.Shoot();
            startTime = 0;
        }
    }
}
