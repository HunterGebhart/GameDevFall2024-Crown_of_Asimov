using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * A class that defines the enemy manager, which keeps track of when enemies are activated
 * for the purposes of music 
 */
public class EnemyManager : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] AudioManager worldAudioManager;

    [Header("Booleans")]
    [SerializeField] public static bool inCombat = false;

    private int numActivatedEnemies;

    //A getter and setter to modify the number of how many number of enemies are currently activated
    public int NumActivatedEnemies
    {
        //Return the number of currently activated enemies
        get
        {
            return numActivatedEnemies;
        }

        //Modify the value of numActivatedEnemies, if no active enemies, call outOfCombat
        set
        {
            numActivatedEnemies = value;

            if(numActivatedEnemies <= 0)
            {
                outOfCombat();
            }
        }
    }

    //Start the game with zero activated enemies, and get components
    private void Start()
    {
        numActivatedEnemies = 0;
        worldAudioManager = worldAudioManager.GetComponent<AudioManager>();
    }

    //If the player isn't in combat and combat music isn't playing, then play combat
    private void Update()
    {
        if(inCombat && !worldAudioManager.combatMusic.isPlaying)
        {
            worldAudioManager.PlayCombatMusic();
        }
    }

    //If there are no active enemies, set the flag to false and play ambience if it isn't already playing
    private void outOfCombat()
    {
        inCombat = false;
        if(!worldAudioManager.ambience.isPlaying) worldAudioManager.PlayAmbience();
    }

    //Modify the inCombat boolean
    public void SetCombat(bool value)
    {
        inCombat = value;
    }
}
