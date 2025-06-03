
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource AudioMenu;
    [SerializeField] AudioClip TemaMenu;

    private void Start()
    {
        AudioMenu.clip = TemaMenu;
        AudioMenu.Play();

    }
}
