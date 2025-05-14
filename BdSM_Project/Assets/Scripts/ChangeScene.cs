using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int thislevel;
    public bool isLoading = false;
    public static ChangeScene instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        isLoading = false;
    }
    public void AdvanceLevel()
    {
        thislevel = SceneManager.GetActiveScene().buildIndex;
        LoadLevel(1);
        isLoading = false;
    }

    public void ResetLevel()
    {
        thislevel = SceneManager.GetActiveScene().buildIndex;
        LoadLevel(0);
        isLoading = false;
    }

    private void LoadLevel(int levelIncrease)
    {
        if (!isLoading)
        {
            SceneManager.LoadScene(thislevel + levelIncrease);
            isLoading = true;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Esta fuerisima ya");
    }
}
