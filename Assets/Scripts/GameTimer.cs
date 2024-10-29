using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    private int minutes = 0, seconds = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string sec, min;
        string mili = Time.timeSinceLevelLoad.ToString().Substring(Time.timeSinceLevelLoad.ToString().IndexOf(".") + 1, 1) + "0";

        if(seconds >= 60)
        {
            minutes++;
        }

        seconds = (int)Time.timeSinceLevelLoad - (minutes * 60);

        if(seconds > 9)
        {
            sec = seconds.ToString();
        }

        else
        {
            sec = "0" + seconds.ToString();
        }

        if(minutes > 9)
        {
            min = minutes.ToString();
        }

        else
        {
            min = "0" + minutes.ToString();
        }

        timerText.text = min + ":" + sec + ":" + mili;
    }
}
