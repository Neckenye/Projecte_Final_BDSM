using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Char_WinCompare : MonoBehaviour
{    
    // On collision enter to Char, go to next level, and if its a trap, restart level.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            Debug.Log("Collision Sucess");
            ChangeScene.instance.AdvanceLevel();
        }
    }    
}
