using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * A class that defines the behavior for an object that periodically spawns moving platforms
 */
public class PlatformSpawner : MonoBehaviour
{
    [Header("Object to Spawn")]
    [SerializeField] GameObject platform;

    [Header("Spawn Location")]
    [SerializeField] Transform spawnPoint;

    [Header("Attributes")]
    [SerializeField] float spawnRate;

    //Start the coroutine to spawn platforms over intervals
    void Start()
    {
        StartCoroutine(SpawnPlatforms());
    }

    //Spawn platforms over time and wait for a certain amount of time
    IEnumerator SpawnPlatforms()
    {
        while(true)
        {
            Instantiate(platform, spawnPoint.position, Quaternion.identity);
            
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
