using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * A class that defines the behavior of the enemy AI
 */
public class PathfindingAI : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] Transform player;
    [SerializeField] Transform headLocation;
    [SerializeField] EnemyManager enemyManager;

    [Header("AI Attributes")]
    [SerializeField] float activationDistance = 10f;
    [SerializeField] float attackDistance = 10f;
    [SerializeField] float shootingCooldown = 3f;
    [SerializeField] float sightDistance = 100f;

    [Header("Activation Settings")]
    [SerializeField] bool activated = false;

    [Header("AI Classification")]
    [SerializeField] bool hasRangedAttacks = false;
    [SerializeField] bool hasMeleeAttacks = false;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bulletAudio;

    private float startTime = 0;

    private int activatedCount;

    private NavMeshAgent agent;

    private EnemyProjectile enemyProjectile;

    private Ray sightRay;
    
    //Get components and set the number of activated enemies in the game to zero
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyProjectile = GetComponent<EnemyProjectile>();

        activatedCount = 0;
    }

    private void Update()
    {
        //Cast a ray from the head of the enemy entity
        RaycastHit hit;
        sightRay = new Ray(headLocation.transform.position, player.transform.position - transform.position - new Vector3(0,2,0));

        //Set booleans if they are in activation/shooting range or not
        bool inShootingRange = Vector3.Distance(transform.position, player.position) <= attackDistance;
        bool inActivationRange = Vector3.Distance(transform.position, player.position) <= activationDistance;
    
        //If the enemy entity is able to be activated and has sight of the player, activate the enemy entity
        if(inActivationRange && Physics.Raycast(sightRay, out hit, sightDistance) && hit.collider.CompareTag("Player"))
        {
            activated = true;
        }

        //If the enemy is activated
        if(activated)
        {
            //If this enemy hasn't yet signaled the EnemyManager that it has been activated
            if(activatedCount < 1) 
            {
                //Increase the activationCount by 1, and increase the EnemyManagers NumActivatedEnemies by 1, then set combat to true
                activatedCount++;
                enemyManager.NumActivatedEnemies +=1;

                enemyManager.SetCombat(true);
            }
            
            //If player is in shooting range and the enemy has sight of the player, attack the player
            if(inShootingRange && Physics.Raycast(sightRay, out hit, sightDistance) && hit.collider.CompareTag("Player"))
            {
                //Stop the enemy entity and execute the attack
                agent.isStopped = true;

                AttackPlayer();
            }

            //If not close enough to the player, or no line of sight, then move the enemy entity and set the destination to the player
            else
            {
                agent.isStopped = false;
                agent.destination = player.position;
            }

            //Look at the player every frame, so the enemy entity is always facing the player
            LookAtPlayer();
        }
    }

    //Rotate the enemy entity to look at the position of the player
    private void LookAtPlayer()
    {
        Vector3 lookPos = player.position - transform.position;

        lookPos.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookPos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    //A method that defines the attack behvior of the enemy entity
    private void AttackPlayer()
    {
        //Start the initial time for cooldown purposes
        if(startTime == 0)
        {
            startTime = Time.time;
        }
        
        //If off cooldown
        if(Time.time > startTime + shootingCooldown)
        {
            //If the enemy has shooting attacks, then play audio and fire the projectile
            if(hasRangedAttacks)
            {
                bulletAudio.Play();
                enemyProjectile.Shoot();

                startTime = 0;
            }
            
            //If the enemy entity has melee attacks (Not fully implemented in final build)
            if(hasMeleeAttacks)
            {
                startTime = 0;
            }
        }
    }
}
