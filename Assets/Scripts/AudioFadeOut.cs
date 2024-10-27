using UnityEngine;
using System.Collections;

public static class AudioFadeOut {

    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        
        float startVolume = audioSource.volume;
        float adjustedVolume = startVolume;


        while (adjustedVolume > 0) {

            adjustedVolume -= startVolume * Time.deltaTime / FadeTime;

            audioSource.volume = adjustedVolume;

            yield return null;
        }

        audioSource.Stop ();
        
        audioSource.volume = startVolume;
    }

}