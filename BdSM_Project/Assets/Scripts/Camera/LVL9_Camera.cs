using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL9_Camera : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed;
    private int nextPlatform = 1;
    private bool platformOrder = true;

    void Start()
    {
        
    }
    void Update()
    {
        if (platformOrder && nextPlatform + 1 >= wayPoints.Length)
        {
            platformOrder = false;
        }

        if (!platformOrder && nextPlatform <= 0)
        {
            platformOrder = true;
        }

        if (Vector2.Distance(transform.position, wayPoints[nextPlatform].position) < 0.1f)
        {
            if (platformOrder)
            {
                nextPlatform += 1;
            }
            else
            {
                nextPlatform -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextPlatform].position, speed * Time.deltaTime);
        transform.position -= new Vector3(0,0,10);
    }
}
