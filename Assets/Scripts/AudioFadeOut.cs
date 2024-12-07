using UnityEngine;
using System.Collections;

/*
 * A class that defines a coroutine to fade out audio tracks, used to fade between ambience and combat music
 */
public static class AudioFadeOut {

    //Static FadeOut coroutine that takes an audio source to fade out from and the time frame to fade over 
    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        
        //Set the starting volume and create a variable to adjust over time
        float startVolume = audioSource.volume;
        float adjustedVolume = startVolume;

        //Slowly set the volume to zero over time
        while (adjustedVolume > 0) {

            adjustedVolume -= startVolume * Time.deltaTime / FadeTime;

            audioSource.volume = adjustedVolume;

            yield return null;
        }

        //Stop the audio once the volume reaches zero
        audioSource.Stop ();
        
        //Set the audio back to initial volume to be played again later
        audioSource.volume = startVolume;
    }

}