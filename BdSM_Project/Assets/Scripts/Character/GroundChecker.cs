using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    public UnityEvent groundHitEvent;
    public UnityEvent groundNoHitEvent;
    
    public string[] collidableTags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{transform.parent.name} collided with {collision.name} with tag {collision.tag}");
        if (TagCompare(collision))
        {
            groundHitEvent?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (TagCompare(collision))
        {
            groundHitEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"{transform.parent.name} exited collision with {collision.name} with tag {collision.tag}");
        if (TagCompare(collision))
        {
            groundNoHitEvent?.Invoke();
        }
    }

    private bool TagCompare(Collider2D collision)
    {
        foreach (string tag in collidableTags)
        {
            if (collision.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
