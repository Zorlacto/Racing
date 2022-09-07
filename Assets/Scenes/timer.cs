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
        { return; }

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timertext.text = minutes + ":" + seconds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Finnish"))
        {
            Time.timeScale = 0;
            print("poop");
        }
    }
  
}
