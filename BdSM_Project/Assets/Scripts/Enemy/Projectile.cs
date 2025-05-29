using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    private Rigidbody2D rb;
    [SerializeField] public Vector2 _desireDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _desireDirection.Normalize();
        LaunchProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MustardTurret") == false && collision.gameObject.CompareTag("Spike") == false)
        {
            Destroy(gameObject);
        }
    }

    private void LaunchProjectile()
    {
        Vector2 direction = _desireDirection;
        rb.velocity = direction * speed;
    }
}
