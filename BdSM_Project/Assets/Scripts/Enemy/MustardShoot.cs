using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret_Shoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetweenShoots = 1;
    [SerializeField] private float ShootAfter;
    [SerializeField] private float projectileDirectionX;
    [SerializeField] private float projectileDirectionY;
    private float timeBetweenShootsCopy;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShootsCopy = timeBetweenShoots + ShootAfter;
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenShootsCopy -= Time.deltaTime;
        if (timeBetweenShootsCopy <= 0)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            Projectile component = projectile.GetComponent<Projectile>();
            component._desireDirection.y = projectileDirectionY;
            component._desireDirection.x = projectileDirectionX;
            timeBetweenShootsCopy = timeBetweenShoots;

            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //Projectile component = projectile.GetComponent<Projectile>();
            //component._desireDirection.x = 1;
            //timeBetweenShootsCopy = timeBetweenShoots;
            //Debug.Log("Spawned projectile");
        }
    }
}
