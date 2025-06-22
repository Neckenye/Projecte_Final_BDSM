using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Jump : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    public Vector2 _desireDirection = Vector2.zero;
    public float jump = 100;
    public bool grounded = false;
    public bool shouldJump = false;

    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void GroundHitCallBack()
    {
        Debug.Log($"{gameObject.name} changed state: grounded");
        grounded = true;
    }

    public void GroundNoHitCallBack()
    {
        Debug.Log($"{gameObject.name} changed state: airborne");
        grounded = false;
    }

    private void FixedUpdate()
    {
        if (shouldJump && grounded)
        {
            _rigidbody2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
        shouldJump = false;
    }
}
