using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public class OptionsMenu : MonoBehaviour
{
    public Transition sceneTransition;

    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    private GameObject graphicsMenuHolder;
    private GameObject optionsMenuHolder;
    private GameObject controlsMenuHolder;
    private GameObject audioMenuHolder;

    Resolution[] resolutions;

    void Awake()
    {
        graphicsMenuHolder = GameObject.Find("GraphicsMenuHolder");
        optionsMenuHolder = GameObject.Find("OptionsMenuHolder");
        controlsMenuHolder = GameObject.Find("ControlsMenuHolder");
        audioMenuHolder = GameObject.Find("AudioMenuHolder");

        graphicsMenuHolder.SetActive(false);
        controlsMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
        audioMenuHolder.SetActive(false);
    }

    void Start()
    {
        sceneTransition = GameObject.Find("LevelManager").GetComponent<Transition>();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<String> options = new List<String>();

        int currResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRateRatio + "hz";
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void setSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void setAmbienceVolume(float volume)
    {
        audioMixer.SetFloat("AmbienceVolume", volume);
    }

    public void setMouseSensitivity(float sensitivity)
    {

    }

    public void OnBackButton()
    {
        sceneTransition.LoadLevel("Main_Menu");
        //SceneManager.LoadScene("Main_Menu");
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void showGraphicsMenuHolder()
    {
        graphicsMenuHolder.SetActive(true);
        controlsMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
        audioMenuHolder.SetActive(false);
    }

    public void showControlsMenuHolder()
    {
        graphicsMenuHolder.SetActive(false);
        controlsMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
        audioMenuHolder.SetActive(false);
    }

    public void showOptionsMenuHolder()
    {
        graphicsMenuHolder.SetActive(false);
        controlsMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
        audioMenuHolder.SetActive(false);
    }

    public void showAudioMenuHolder()
    {
        graphicsMenuHolder.SetActive(false);
        controlsMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
        audioMenuHolder.SetActive(true);
    }
}
