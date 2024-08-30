using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenericShotgun : MonoBehaviour
{
    public GameObject ShotProjectile;
    public Transform BulletSpawn;
    public float fireRate;
    public float angleBullets;
    private float nextFire;


private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(ShotProjectile, BulletSpawn.position, BulletSpawn.rotation);
            Instantiate(ShotProjectile, BulletSpawn.position, Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + angleBullets, 0)));
            Instantiate(ShotProjectile, BulletSpawn.position, Quaternion.Euler(new Vector3(0, transform.eulerAngles.y - angleBullets, 0)));
        }
    }
}
