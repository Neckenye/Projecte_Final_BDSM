using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public static bool easyMode;
    void Start()
    {
        easyMode = false;
    }

    public void ActivateEasyMode()
    {
        easyMode = true;
    }
}
