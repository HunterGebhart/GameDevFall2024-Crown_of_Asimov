using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource combatMusic;
    [SerializeField] private AudioSource ambience;
    void Awake()
    {
        PlayAmbience();
    }

    public void PlayCombatMusic()
    {
        //ambience.Stop();
        combatMusic.Play();
    }

    public void PlayAmbience()
    {
        //combatMusic.Stop();
        ambience.Play();
    }
}
