using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] public GameObject enemyManager;
    [SerializeField] GameObject revolver;

    [Header("Entity Attributes")]
    [SerializeField] private float startingHealth;

    [SerializeField] private AudioSource damagedAudio;
    [SerializeField] private AudioSource destroyedAudio;
    //[SerializeField] private AudioClip damagedAudio;
    //[SerializeField] private AudioClip destroyedAudio;

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
                destroyedAudio.Play();
                //revolver.GetComponent<PlayerGun>().CurrAmmo += (int)startingHealth;
                enemyManager.GetComponent<EnemyManager>().NumEnemies -= 1;
                
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
