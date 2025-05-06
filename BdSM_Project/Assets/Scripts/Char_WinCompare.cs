using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Char_WinCompare : MonoBehaviour
{
    //Index of actual scene
    public int nextlevel = SceneManager.GetActiveScene().buildIndex;

    // On collision enter to Char, if the tag is other Char, charge next level
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TagCompare(collision))
        {
            Debug.Log("Collision Sucess");
            ChangeLevel(nextlevel + 1); //El número mas uno 
        }
    }

    //Compare the tag with the object collider
    private bool TagCompare(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            return true;
        }
        return false;
    }

    //Method to charge the next level
    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
