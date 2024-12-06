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

    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;

    public Slider masterVolumeSlider;

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

        setFullscreenToggle();
        setVsyncToggle();
        setMasterVolumeSlider();
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
        PlayerPrefs.SetFloat("MasterVolume", volume);
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void setMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void setSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void setAmbienceVolume(float volume)
    {
        PlayerPrefs.SetFloat("AmbienceVolume", volume);
        audioMixer.SetFloat("AmbienceVolume", volume);
    }

    public void OnBackButton()
    {
        sceneTransition.LoadLevel("Main_Menu");
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        if(isFullscreen) PlayerPrefs.SetInt("isFullscreen", 1);
        else PlayerPrefs.SetInt("isFullscreen", 0);
        Screen.fullScreen = isFullscreen;
    }

    public void setVsync(bool isVsync)
    {
        if(isVsync) 
        {
            PlayerPrefs.SetInt("isVsync", 1);
            QualitySettings.vSyncCount = 1;
        }
        else 
        {
            PlayerPrefs.SetInt("isVsync", 0);
            QualitySettings.vSyncCount = 0;
        }
        
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

    public void setFullscreenToggle()
    {
        if(PlayerPrefs.GetInt("isFullscreen") == 1)
        {
            int isFullscreen = PlayerPrefs.GetInt("isFullscreen");
            if(isFullscreen == 1) fullscreenToggle.isOn = true;
            else fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }
    }

    public void setVsyncToggle()
    {
        if(PlayerPrefs.GetInt("isVsync") == 1)
        {
            int vsync = PlayerPrefs.GetInt("isVsync");
            if(vsync == 1) vsyncToggle.isOn = true;
            else vsyncToggle.isOn = false;
        }
        else
        {
            vsyncToggle.isOn = false;
        }
    }

    public void setMasterVolumeSlider()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    public void setMouseSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
    }

    public void setFieldOfView(float FOV)
    {
        PlayerPrefs.SetFloat("FieldOfView", FOV);
    }
}
