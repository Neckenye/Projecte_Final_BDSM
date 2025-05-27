using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider sliderOne;
    public Slider sliderTwo;
    private float myTime;
    public float initialTime;
    public bool stopTime;

    void Start()
    {
        myTime = initialTime;

        sliderOne.maxValue = initialTime;
        sliderOne.value = initialTime;

        sliderTwo.maxValue = initialTime;
        sliderTwo.value = initialTime;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (myTime <= 0)
        {
            ChangeScene.instance.ResetLevel();
            stopTime = true ;
            
        }

        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.J)) 
        {
            stopTime = false;
        }

        if (stopTime == false )
        {
            myTime = myTime - Time.deltaTime;
            sliderOne.value = myTime;
            sliderTwo.value = myTime;
        }
        
    }
}
