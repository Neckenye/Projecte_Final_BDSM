using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Movement : MonoBehaviour
{

    public string _horizontalInputAxisName = "Horizontal";
    public string _verticalInputAxisName = "Vertical";

    public float speed = 10.0f;

    private Rigidbody2D _rigidbody2D;

    public Vector2 _desireDirection = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 6)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _desireDirection.x = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _desireDirection.x = -1;
            }
            else
            {
                _desireDirection.x = 0;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.L))
            {
                _desireDirection.x = 1;
            }
            else if (Input.GetKey(KeyCode.J))
            {
                _desireDirection.x = -1;
            }
            else
            {
                _desireDirection.x = 0;
            }
        }
        _desireDirection.Normalize();
    }

    private void FixedUpdate()
    {
        Vector2 l_currentPosition = transform.position;
        _rigidbody2D.AddForce(_desireDirection * speed, ForceMode2D.Impulse);
    }
}
