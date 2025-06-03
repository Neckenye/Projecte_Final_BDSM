using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Jump : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    public Vector2 _desireDirection = Vector2.zero;
    public float salto = 100;
    public bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            if (gameObject.CompareTag("Character"))
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    _rigidbody2D.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.I))
                {
                    _rigidbody2D.AddForce(Vector2.up * salto, ForceMode2D.Impulse);

                }
            }
        }
    }
    
    //The grounded bool is true if the event is the Ground Hit.
    public void GroundHitCallBack()
    {
        Debug.Log($"{gameObject.name} changed state: grounded");
        grounded = true;
    }

    //The grounded bool is false if the event is the Ground NO Hit.
    public void GroundNoHitCallBack()
    {
        Debug.Log($"{gameObject.name} changed state: airborne");
        grounded = false;
    }

    private void FixedUpdate()
    {

    }
}
