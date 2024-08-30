using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUlt : MonoBehaviour
{

    public GameObject GlobalVars;
    public bool OnCooldown;

    private PlayerStats PlayerStats;
    private GameObject origShootObject;

    private void Start()
    {
        PlayerStats = GlobalVars.GetComponent<PlayerStats>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("x"))
        {
            if(PlayerStats.Ultimates > 0 && !OnCooldown)
            {
                Debug.Log("InvincibleULT");
                GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>().isOnUlt = true;
                Debug.Log(PlayerStats.isOnUlt);
                OnCooldown = !OnCooldown;
                gameObject.GetComponent<PlayerHealthNPoints>().IsInvincible = true;
                Invoke("MakeMortal", 10f);
                Invoke("ChangeCooldown", 20f);
            }
        }
        if (Input.GetKey("y"))
        {
            if (PlayerStats.Ultimates > 0 && !OnCooldown)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>().isOnUlt = true;
                OnCooldown = !OnCooldown;

                gameObject.GetComponent<playerShoot>().ShotProjectile.GetComponent<BulletScript>().damageVal = 3;

                Debug.Log("Damage Increase");

                Invoke("ChangeBackBullet", 10f);
                Invoke("ChangeCooldown", 20f);
            }
        }
    }

    private void ChangeBackBullet()
    {
        gameObject.GetComponent<playerShoot>().ShotProjectile.GetComponent<BulletScript>().damageVal = 1;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>().isOnUlt = false;
    }

    private void MakeMortal()
    {
        gameObject.GetComponent<PlayerHealthNPoints>().IsInvincible = false;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>().isOnUlt = false;
    }

    private void ChangeCooldown()
    {
        OnCooldown = !OnCooldown;
    }
}
