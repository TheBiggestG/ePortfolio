using System;
using System.Timers;
using UnityEngine;


public class HealthSystemEnemy : MonoBehaviour
{
    public int cooldown;
    public GameObject Point;
    private bool IsInvincible = true;
    public byte Health = 3;
    private void Start()
    {
        Invoke("makeMortal", cooldown);
    }

    private void makeMortal()
    {
        IsInvincible=false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FriendlyBullet" && IsInvincible == false)
        {
            Debug.Log("Hit");
            Health -= other.GetComponent<BulletScript>().damageVal;

            if(Health <= 0)
            {
                Debug.Log("Destroyed");
                Instantiate(Point.gameObject, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            } 
        }
    }
}
