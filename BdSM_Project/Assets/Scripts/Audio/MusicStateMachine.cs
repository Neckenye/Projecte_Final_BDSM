using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStateMachine : MonoBehaviour
{
    public enum State
    {
        MenuSong,
        ChillSong,
        FastSong
    }

    private State currentState;
    float dt = Time.deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.MenuSong;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.MenuSong:
                {
                    MenuSong(dt);
                    break;
                }
            case State.ChillSong:
                {
                    ChillSong(dt);
                    break;
                }
            case State.FastSong:
                {
                    FastSong(dt);
                    break;
                }
            default: break;
        }
    }

    public void ChangeState(State newState)
    {
        if (currentState == State.MenuSong)
        {
            MenuSong(dt);
        }
        else if (currentState == State.ChillSong)
        {
            ChillSong(dt);
        }
        else if (currentState == State.FastSong)
        {
            FastSong(dt);
        }



        if (newState == State.MenuSong)
        {

        }
        else if (newState == State.ChillSong)
        {

        }
        else if (newState == State.FastSong)
        {

        }


    }

    private void MenuSong(float dt)
    {

    }
    private void ChillSong(float dt)
    {

    }
    private void FastSong(float dt)
    {

    }
}
