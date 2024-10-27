using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Music Tracks")]
    [SerializeField] private AudioSource combatMusic;
    [SerializeField] private AudioSource ambience;

    void Awake()
    {
        PlayAmbience();
    }

    public void PlayCombatMusic()
    {
        StartCoroutine(AudioFadeOut.FadeOut(ambience, 0.8f));
        combatMusic.Play();
    }

    public void PlayAmbience()
    {
        StartCoroutine(AudioFadeOut.FadeOut(combatMusic, 4f));
        ambience.Play();
    }
}
