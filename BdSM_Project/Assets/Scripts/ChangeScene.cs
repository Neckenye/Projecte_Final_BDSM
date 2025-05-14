using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
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
        LoadLevel(1);
    }

    public void ResetLevel()
    {
        LoadLevel(0);
    }

    private void LoadLevel(int levelIncrease)
    {
        if (!isLoading)
        {
            int thislevel = SceneManager.GetActiveScene().buildIndex;
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
