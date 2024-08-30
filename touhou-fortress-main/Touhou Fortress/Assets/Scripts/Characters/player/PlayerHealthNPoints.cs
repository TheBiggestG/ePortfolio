using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthNPoints : MonoBehaviour
{
    [SerializeField]
    public GameObject globalVars;

    private PlayerStats stats;
    public bool IsInvincible = false;

    public int health;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit from player" + other.tag);
        if (other.CompareTag("EnemyBullet"))
        {
            Debug.Log("hit from player");
            if (IsInvincible == false)
            {
                stats.ReduceHealth();
            }
        }
        if (other.CompareTag("PointObject"))
        {
            stats.Points += other.gameObject.GetComponent<PointSystem>().Points;
            Debug.Log(stats.Points);
            Destroy(other.gameObject);
        }
    }


    private void Start()
    {
        stats = globalVars.GetComponent<PlayerStats>();
    }
}
