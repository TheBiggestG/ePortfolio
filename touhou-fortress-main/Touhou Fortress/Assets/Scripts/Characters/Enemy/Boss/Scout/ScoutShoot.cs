using UnityEngine;

public class ScoutShoot : MonoBehaviour
{
    public GameObject ShotProjectile;
    public Transform BulletSpawn;
    public float fireRate;
    public float angleBullets;
    public byte shootAmount;
    private float nextFire;

    private float defFireRate;
    private float defAngleBullets;
    private byte defShootAmount;

    private void Start()
    {
        defFireRate = fireRate;
        defAngleBullets = angleBullets;
        defShootAmount = shootAmount;
    }
    void Update()
    {
        ShootFunc();
    }

    public void setShootingMode(float firerate, float anglebullets, byte shootamount)
    {
        fireRate = firerate;
        angleBullets = anglebullets;
        shootAmount = shootamount;
    }

    public void resetShootingMode()
    {
        fireRate = defFireRate;
        angleBullets = defAngleBullets;
        shootAmount = defShootAmount;
    }

    public void ShootFunc()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(ShotProjectile, BulletSpawn.position, BulletSpawn.rotation);

            for(int i = 1; i <= shootAmount; i++)
            {
                Instantiate(ShotProjectile, BulletSpawn.position, Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + angleBullets * i, 0)));
                Instantiate(ShotProjectile, BulletSpawn.position, Quaternion.Euler(new Vector3(0, transform.eulerAngles.y - angleBullets * i, 0)));
            }
        }
    }
}
