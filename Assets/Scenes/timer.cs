using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public GameObject[] characterpre;
    public Text timertext;
    private float startTime;
    private bool finnished = false;
    public TMP_Text whoFinished;
    public GameObject gameover;
    

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
            finnished = true;
            Time.timeScale = 0;
            timertext.color = Color.yellow;
            gameover.SetActive(true);
            int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
            GameObject prefab = characterpre[selectedCharacter];
            whoFinished.text = prefab.name;
            
        }
    }
  
}
