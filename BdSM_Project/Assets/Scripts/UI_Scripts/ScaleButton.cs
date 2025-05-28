using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleButton : MonoBehaviour
{
    public void MouseEnter()
    {
        transform.localScale = new Vector3(2f, 2f);
    }

    public void MouseExit()
    {
        transform.localScale = new Vector3(1.5f, 1.5f);
    }
}
