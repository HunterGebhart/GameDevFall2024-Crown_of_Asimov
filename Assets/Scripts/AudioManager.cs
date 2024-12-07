using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class that defines the behavior of the AudioManager, changing the scene 
 * music between ambience or combat music
 */
public class AudioManager : MonoBehaviour
{
    //The music tracks to be played
    [Header("Music Tracks")]
    [SerializeField] public AudioSource combatMusic;
    [SerializeField] public AudioSource ambience;

    [Header("Fade Out Timers")]
    [SerializeField] float ambienceFadeTime = 0f;
    [SerializeField] float combatFadeTime = 4f;

    //Make sure only ambience is playing at the start of the level
    private void Awake()
    {
        ambience.Stop();
        combatMusic.Stop();
        ambience.Play();
    }

    //Fade out the ambience, then start playing combat music
    public void PlayCombatMusic()
    {
        StartCoroutine(AudioFadeOut.FadeOut(ambience, ambienceFadeTime));
        combatMusic.Play();
    }

    //Fade out the combat music, then start playing the ambience
    public void PlayAmbience()
    {
        StartCoroutine(AudioFadeOut.FadeOut(combatMusic, combatFadeTime));
        ambience.Play();
    }
}
