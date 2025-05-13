using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Char_Movement : MonoBehaviour
{

    public string _horizontalInputAxisName = "Horizontal";
    public string _verticalInputAxisName = "Vertical";

    public float speed = 50.0f;

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
        //_desireDirection.x = Input.GetAxis(_horizontalInputAxisName); Esto hace el movimiento normal con WASD o Flechas

        //If es character uno > if key d = derecha, else if key a = izquierda || else if key l = derecha, else if key j = izquierda
        //6 = Char_1 , 7 = Char_2

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
        //_desireDirection.y += -0.4f;
        _desireDirection.Normalize();
    }

    private void FixedUpdate()
    {
        Vector2 l_currentPosition = transform.position;
        //_rigidbody2D.AddForce(_desireDirection * speed, ForceMode2D.Impulse);

        _rigidbody2D.AddForce(_desireDirection * 50, ForceMode2D.Force);
    }
}
