using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapImageInteract : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            image.enabled = (true);
        }
        else
        {
            image.enabled = (false);
        }

        
        
    }
}
