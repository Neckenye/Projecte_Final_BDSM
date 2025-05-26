using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    //Events to know if the player touch the ground or not
    public UnityEvent groundHitEvent;
    public UnityEvent groundNoHitEvent;
    
    //String array to know what tags are grounderable
    public string[] collidableTags;


    //On trigger enter compare the tags and send the hit event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TagCompare(collision))
        {
            groundHitEvent?.Invoke();
        }
    }

    //On trigger exit compare the tags and send the NO hit event
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (TagCompare(collision))
        {
            groundNoHitEvent?.Invoke();
        }
    }

    //Only compare tags
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
