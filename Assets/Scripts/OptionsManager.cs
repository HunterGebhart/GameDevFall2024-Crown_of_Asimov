using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        setDefaultFullscreen();
        setDefaultMasterVolume();

        //setFullscreen();
    }
/*
    public void setFullscreen()
    {
        if(PlayerPrefs.GetInt("isFullscreen") == 1)
        {
            int isFullscreen = PlayerPrefs.GetInt("isFullscreen");
            if(isFullscreen == 1) Screen.fullScreen = true;
            else Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }

    public void setVsync()
    {
        if(PlayerPrefs.GetInt("isVsync") == 1)
        {
            int vsync = PlayerPrefs.GetInt("isVsync");
            if(vsync == 1) QualitySettings.vSyncCount = 1;
            else QualitySettings.vSyncCount = 0;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }*/

    public void setDefaultFullscreen()
    {
        PlayerPrefs.SetInt("isFullscreen", 1);
    }

    public void setDefaultMasterVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", -5f);
    }
}
