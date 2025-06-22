using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource AudioSource;

    public AudioClip MenuSong;
    public AudioClip ChillSong;
    public AudioClip FastSong;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaySong(MenuSong);
    }


    public void PlaySong(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.Play();
    }
}

