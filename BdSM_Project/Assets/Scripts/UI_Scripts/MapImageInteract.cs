using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapImageInteract : MonoBehaviour
{
    private UnityEngine.UI.RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.RawImage>();
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
