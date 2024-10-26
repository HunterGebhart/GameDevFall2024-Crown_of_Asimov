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
                //revolver.GetComponent<PlayerGun>().CurrAmmo += (int)startingHealth;
                enemyManager.GetComponent<EnemyManager>().NumEnemies -= 1;
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        Health = startingHealth;
    }
}
