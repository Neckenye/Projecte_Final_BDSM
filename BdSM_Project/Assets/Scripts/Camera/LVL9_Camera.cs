using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL9_Camera : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float velocity;
    private int nextPlatform = 1;
    private bool platformOrder = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextPlatform].position, velocity * Time.deltaTime);
        transform.position -= new Vector3(0,0,10);
    }
}
