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

        thislevel = SceneManager.GetActiveScene().buildIndex;
        isLoading = false;
    }
    public void AdvanceLevel()
    {        
        LoadLevel(1);
        isLoading = false;
        thislevel = thislevel + 1;
    }

    public void ResetLevel()
    {
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
