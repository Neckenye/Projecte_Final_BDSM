using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    public Vector2 _desireDirection = Vector2.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _desireDirection.x = 1;
        _desireDirection.y = 0;
        _desireDirection.Normalize();
        LaunchProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void LaunchProjectile()
    {
        Vector2 direction = _desireDirection;
        rb.velocity = direction * speed;
    }
}
