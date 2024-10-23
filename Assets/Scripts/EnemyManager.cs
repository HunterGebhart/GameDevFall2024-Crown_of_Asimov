using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject levelCollider;

    public int numEnemies;

    public int NumEnemies
    {
        get
        {
            return numEnemies;
        }
        set
        {
            numEnemies = value;
            Debug.Log(numEnemies);

            if(numEnemies <= 0f)
            {
                action();
            }
        }
    }

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void action()
    {
        Debug.Log("Level Complete!");
        levelCollider.GetComponent<NextLevelLoader>().makeActive();
    }
}
