using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * A class that defines an object that determines whether there are enemies in a room, and triggers objects if not
 */
public class CombatZone : MonoBehaviour
{
    [Header("Objects References")]
    [SerializeField] Light exitLight;
    [SerializeField] GameObject roomTrigger;
    [SerializeField] GameObject holderObject;

    private static bool enemiesInRoom;
    
    //Set the boolean to true, because there are always enemies in the room on startup
    void Start()
    {
        enemiesInRoom = true;
    }

    //Update is called once per frame
    void Update()
    {
        //If the number of enemies in the holder are zero, then set enemiesInRoom to false
        if(holderObject.transform.childCount <= 0)
        {
            enemiesInRoom = false;
        }
        
        //If there are no enemies in the room, trigger the objects and turn the light to green
        if(enemiesInRoom == false)
        {
            roomTrigger.SetActive(true);
            exitLight.transform.GetComponent<Light>().color = Color.green / 1.2f;
        }

        //If there are enemies in the room, disable the objects and turn the light to red
        if(enemiesInRoom == true)
        {
            roomTrigger.SetActive(false);
            exitLight.transform.GetComponent<Light>().color = Color.red / 1.2f;
        }
    }
}
