using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] GameObject levelCollider;
    [SerializeField] GameObject worldAudioManager;

    [Header("Enemy Management")]
    [SerializeField] int numEnemies;

    [Header("Booleans")]
    [SerializeField] public bool inCombat = false;

    public int NumEnemies
    {
        get
        {
            return numEnemies;
        }
        set
        {
            numEnemies = value;

            if(numEnemies <= 0f)
            {
                action();
            }
        }
    }

    void action()
    {
        worldAudioManager.GetComponent<AudioManager>().PlayAmbience();
        levelCollider.SetActive(true);
    }

    public void SetCombat()
    {
        Debug.Log("C");
        inCombat = true;
        worldAudioManager.GetComponent<AudioManager>().PlayCombatMusic();
    }
}
