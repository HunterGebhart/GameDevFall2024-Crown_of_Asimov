using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] GameObject revolver;
    [SerializeField] EnemyManager enemyManager;

    [Header("Entity Attributes")]
    [SerializeField] private float startingHealth;

    [SerializeField] private AudioSource damagedAudio;
    [SerializeField] private AudioSource destroyedAudio;

    private float health;

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;

            if(health <= 0f)
            {
                enemyManager.SetCombat(false);

                destroyedAudio.Play();

                enemyManager.NumActivatedEnemies -= 1;
                
                Destroy(gameObject, .6f);
            }

            else if (health < startingHealth)
            {
                damagedAudio.Play();
            }
        }
    }

    void Start()
    {
        Health = startingHealth;
    }
}
