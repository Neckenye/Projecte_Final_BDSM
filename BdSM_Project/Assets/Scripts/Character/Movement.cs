using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class New_Char_Move : MonoBehaviour
{
    enum InputSchema
    {
        WASD,
        IJKL
    };

    private Rigidbody2D rb;

    private float horizontalMov;
    [SerializeField] private float velocityMov;
    [Range(0f, 1f)][SerializeField] private float softMov;    //Suavizado de movimineto
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float characterSize;
    private bool lookingRight = true;
    [SerializeField] InputSchema selectedSchema;
    Char_Jump jumpComponent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Assert(rb != null);
        jumpComponent = GetComponent<Char_Jump>();
        Debug.Assert(jumpComponent != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedSchema == InputSchema.WASD)
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

            if (Input.GetKey(KeyCode.W))
            {
                jumpComponent.shouldJump = true;
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

            if (Input.GetKey(KeyCode.I))
            {
                jumpComponent.shouldJump = true;
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

