using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject ShotProjectile;
    public Transform BulletSpawn;
    public float fireRate;

    private float nextFire;

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(ShotProjectile, BulletSpawn.position, BulletSpawn.rotation);
        }
    }
}
