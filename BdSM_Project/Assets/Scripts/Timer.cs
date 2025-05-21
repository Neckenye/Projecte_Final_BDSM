using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider sliderOne;
    public Slider sliderTwo;
    public float myTime;
    public bool stopTime;

    void Start()
    {
        stopTime = false;

        sliderOne.maxValue = myTime;
        sliderOne.value = myTime;

        sliderTwo.maxValue = myTime;
        sliderTwo.value = myTime;
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
            sliderOne.value = currentTime;
            sliderTwo.value = currentTime;
        }
        
    }
}
