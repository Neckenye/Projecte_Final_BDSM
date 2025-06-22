
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioMenu;
    [SerializeField] AudioClip SongMenu;

    private void Start()
    {
        AudioMenu.clip = SongMenu;
        AudioMenu.Play();
    }
}
