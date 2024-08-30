using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoutHealth : MonoBehaviour
{
    public int health;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FriendlyBullet"))
        {
            health -= other.gameObject.GetComponent<BulletScript>().damageVal;
            Debug.Log("Hit: " + health);
            if(health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
