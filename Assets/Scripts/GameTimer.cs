using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * A class that defines the game timer on the player HUD
 */ 
public class GameTimer : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TMP_Text timerText;

    private int minutes = 0, seconds = 0;

    private void Update()
    {
        //Extract the digits from the raw time float
        string sec, min;
        string mili = Time.timeSinceLevelLoad.ToString().Substring(Time.timeSinceLevelLoad.ToString().IndexOf(".") + 1, 1) + "0";

        //Increment the minutes if seconds reaches 60
        if(seconds >= 60)
        {
            minutes++;
        }

        //Initialize seconds
        seconds = (int)Time.timeSinceLevelLoad - (minutes * 60);

        //If seconds is 9, set the string to '9'
        if(seconds > 9)
        {
            sec = seconds.ToString();
        }
        //If seconds is not 9, add a '0' in front of the digit
        else
        {
            sec = "0" + seconds.ToString();
        }

        //If minutes is 9, set the string to '9'
        if(minutes > 9)
        {
            min = minutes.ToString();
        }
        //If the minutes is not 9, add a '0' in front of the digit
        else
        {
            min = "0" + minutes.ToString();
        }

        //Set the text with the appropriate values
        timerText.text = min + ":" + sec + ":" + mili;
    }
}
