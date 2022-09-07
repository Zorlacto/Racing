using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class timer : MonoBehaviour
{

    public Text timertext;
    private float startTime;
    private bool finnished = false;

    void Start()
    {
        startTime = Time.time;
    }

    
    void Update()
    {
        if (finnished)
            return;
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timertext.text = minutes + ":" + seconds;
    }

    public void Finnish()
    {
        finnished = true;
        timertext.color = Color.yellow;
    }
}
