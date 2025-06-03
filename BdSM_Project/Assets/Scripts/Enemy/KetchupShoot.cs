using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class KetchupShoot : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float timeBetweenShoots = 1;
    [SerializeField] private float timeShooting = 2;
    [SerializeField] private float ShootAfter;
    [SerializeField] private float projectileDirectionX;
    [SerializeField] private float projectileDirectionY;
    private float timeBetweenShootsCopy;
    private float timeShootingCopy;


    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShootsCopy = timeBetweenShoots + ShootAfter;
        timeShootingCopy = timeShooting;
    }

    void Update()
    {
        timeBetweenShootsCopy -= Time.deltaTime;
        if (timeBetweenShootsCopy <= 0)
        {
            while (timeShootingCopy > 0)
            {
                GameObject projectile = Instantiate(laserPrefab, transform.position, transform.rotation);
                Projectile component = projectile.GetComponent<Projectile>();
                component._desireDirection.y = projectileDirectionY;
                component._desireDirection.x = projectileDirectionX;
                timeShootingCopy -= Time.deltaTime;
            }
            timeBetweenShootsCopy = timeBetweenShoots;
            timeShootingCopy = timeShooting;
        }
    }
}
