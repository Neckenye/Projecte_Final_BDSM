using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class New_Char_Move : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontalMov;
    [SerializeField] private float velocityMov;
    [Range(0f, 1f)][SerializeField] private float softMov;    //Suavizado de movimineto
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float characterSize;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 6)
        {
            if (Input.GetKey(KeyCode.D))
            {
                horizontalMov = 1 * velocityMov;
                
            }
            else if (Input.GetKey(KeyCode.A))
            {
                horizontalMov = -1 * velocityMov;
               
            }
            else
            {
                horizontalMov = 0 * velocityMov;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.L))
            {
                horizontalMov = 1 * velocityMov;
                
            }
            else if (Input.GetKey(KeyCode.J))
            {
                horizontalMov = -1 * velocityMov;
                
            }
            else
            {
                horizontalMov = 0 * velocityMov;
            }
        }
    }

    private void FixedUpdate()
    {
        Move(horizontalMov * Time.fixedDeltaTime);
    }

    private void Move(float move)
    {
        Vector3 velocidadObjetivo = new Vector2(move, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, velocidadObjetivo, ref velocity, softMov);

        if (move < 0 && !lookingRight)
        {
            Turn();
        }
        else if (move > 0 && lookingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}

