using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public float myTime;
    public bool stopTime;

    void Start()
    {
        stopTime = false;
        slider.maxValue = myTime;
        slider.value = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = myTime - Time.time;

        if (currentTime <= 0)
        {
            stopTime = true;
        }

        if (stopTime == false )
        {
            slider.value = currentTime;
        }
        
    }
}
