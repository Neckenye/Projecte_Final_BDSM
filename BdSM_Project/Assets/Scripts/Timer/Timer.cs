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
    public static bool startTime;

    private void Awake()
    {
        Debug.Assert(initialTime > 0, "initalTime must be greater than 0!");
    }

    void Start()
    {
        startTime = false;

        myTime = initialTime;

        sliderOne.maxValue = initialTime;
        sliderOne.value = initialTime;

        sliderTwo.maxValue = initialTime;
        sliderTwo.value = initialTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!Input.GetKeyDown(KeyCode.Tab))
            {
                startTime = true;
            }
        }

        if (startTime)
        {
            if (myTime <= 0)
            {
                ChangeScene.instance.ResetLevel();
                stopTime = true;

            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.J))
            {
                stopTime = false;
            }

            if (stopTime == false)
            {
                myTime = myTime - Time.deltaTime;
                sliderOne.value = myTime;
                sliderTwo.value = myTime;
            }
        }
    }
}
