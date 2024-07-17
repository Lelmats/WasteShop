using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer: MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip timerSoundEffect;
    public AudioClip timerEndSoundEffect;
    public bool Play;
    public float timeValue = 10;
    public float timeRestart;
    public float timeValueFinal;

    public TextMeshPro timerText;
    public TextMeshPro timerText2;

    void Start()
    {
        Play = false;
    }
    public void StartTimer()
    {
        Play = true;
        timeValue = timeRestart;
    }
    public void StopTimer()
    {
        // audioSource.PlayOneShot(timerEndSoundEffect);
        timeValue = 0;
        Play = false;
    }
    
    void Update()
    {
        //Testing the timer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTimer();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StopTimer();
        }
        // Timer
        if (Play == true && timeValue > 0)
        {
            // audioSource.PlayOneShot(timerSoundEffect);
            timeValue -= Time.deltaTime;
            timeValueFinal = timeValue;
        } else
        {
            StopTimer();
        }
        DisplayTime(timeValue);
        // Debug.Log(timeValue);
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
        timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText2.text = timerText.text;

    }
}