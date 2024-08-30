using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHealth : MonoBehaviour
{
    public int health;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FriendlyBullet"))
        {
            health -= other.gameObject.GetComponent<BulletScript>().damageVal;
            //Debug.Log("Hit: " + health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
