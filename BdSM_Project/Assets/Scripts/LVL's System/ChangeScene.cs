using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool isLoading = false;
    public static ChangeScene instance { get; private set; }

    int thislevel;
    int lastScene;

    private void Awake()
    {
        if (instance != null)
        {
            instance.thislevel = SceneManager.GetActiveScene().buildIndex;
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        isLoading = false;

        thislevel = SceneManager.GetActiveScene().buildIndex;
        lastScene = SceneManager.sceneCountInBuildSettings;
    }
    private void Update()
    {
        if (thislevel != 0 && thislevel != lastScene)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetLevel();
            }
        }
    }
    public void AdvanceLevel()
    {
        LoadLevel(1);
    }

    public void ReturnMainMenu()
    {

        LoadLevel(0 - thislevel);
    }

    public void ResetLevel()
    {
        LoadLevel(0);
    }

    private void LoadLevel(int levelIncrease)
    {
        if (!isLoading)
        {
            isLoading = true;
            SceneManager.LoadScene(thislevel + levelIncrease);
        }
        isLoading = false;
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Esta fuerisima ya");
    }
}
