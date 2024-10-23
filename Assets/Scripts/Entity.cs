using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameObject enemyManager;
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
            //Debug.Log(health);

            if(health <= 0f)
            {
                enemyManager.GetComponent<EnemyManager>().NumEnemies -= 1;
                Destroy(gameObject);
            }
        }
    }
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
    }
}
