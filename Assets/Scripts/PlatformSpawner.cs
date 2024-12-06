using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public float spawnRate;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPlatforms()
    {
        while(true)
        {
            Instantiate(platform, spawnPoint.position, Quaternion.identity);
            
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
