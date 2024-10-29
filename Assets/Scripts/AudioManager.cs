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
        ambience.Stop();
        combatMusic.Stop();
        ambience.Play();
    }

    public void PlayCombatMusic()
    {
        StartCoroutine(AudioFadeOut.FadeOut(ambience, 0f));
        combatMusic.Play();
    }

    public void PlayAmbience()
    {
        StartCoroutine(AudioFadeOut.FadeOut(combatMusic, 4f));
        ambience.Play();
    }
}
