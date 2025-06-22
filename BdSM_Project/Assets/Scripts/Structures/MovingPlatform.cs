using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structures : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float velocity;
    private int targetWaypointIndex = 1;
    private bool readFromFirstToLast = true;  // If true: reads form 0 to last (so every time it changes target, index += 1). If false: Reads from last to 0 (so every time it changes target, index -= 1)

    void Start()
    {

    }

    private void Update()
    {
        if (Timer.startTime)
        {
            if (readFromFirstToLast && targetWaypointIndex + 1 >= wayPoints.Length)
            {
                readFromFirstToLast = false;
            }

            if (!readFromFirstToLast && targetWaypointIndex <= 0)
            {
                readFromFirstToLast = true;
            }

            if (Vector2.Distance(transform.position, wayPoints[targetWaypointIndex].position) < 0.1f)
            {
                if (readFromFirstToLast)
                {
                    targetWaypointIndex += 1;
                }
                else
                {
                    targetWaypointIndex -= 1;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, wayPoints[targetWaypointIndex].position, velocity * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Character"))
        {
            collision.transform.SetParent(transform);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Character"))
        {
            collision.transform.SetParent(null);
        }

    }
}
