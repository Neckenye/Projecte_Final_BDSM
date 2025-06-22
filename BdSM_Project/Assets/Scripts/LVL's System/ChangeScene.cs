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

    int sceneIndex;
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
        if (thislevel != 0 && thislevel != 1 && thislevel != lastScene)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetLevel();
            }
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if ((sceneIndex >= 3 && sceneIndex <= 7) && AudioManager.Instance.AudioSource.clip != AudioManager.Instance.ChillSong)
        {
            AudioManager.Instance.PlaySong(AudioManager.Instance.ChillSong);
        }
        if ((sceneIndex >= 8 && sceneIndex <= 14) && AudioManager.Instance.AudioSource.clip != AudioManager.Instance.FastSong)
        {
            AudioManager.Instance.PlaySong(AudioManager.Instance.FastSong);
        }
        if (sceneIndex >= 15)
        {
            AudioManager.Instance.PlaySong(AudioManager.Instance.MenuSong);
        }
    }
    public void AdvanceLevel()
    {
        LoadLevel(1);
    }

    public void AdvanceCustomLevel(int level)
    {
        LoadLevel(level);
        Debug.Log(AudioManager.Instance.AudioSource.clip);
        Debug.Log(level);
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
