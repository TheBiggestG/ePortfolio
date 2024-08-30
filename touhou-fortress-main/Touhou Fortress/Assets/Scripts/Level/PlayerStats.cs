using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public byte Health = 3;
    public uint Points = 0;
    public byte Ultimates = 3;

    public GameObject Player;
    public Transform transformPlayerSpawn;
    public bool isSpawnCooldown = false;
    public bool isOnUlt;

    private void Start()
    {
        instantiatePlayer();
    }

    private void Update()
    {

    }

    public void ReduceHealth()
    {
        if (isSpawnCooldown == false)
        {
            Debug.Log("ok");
            Health--;
            Destroy(GameObject.FindGameObjectWithTag("Player"));

            Invoke("instantiatePlayer", 5f);
            isSpawnCooldown = true;
        }
    }

    public void instantiatePlayer()
    {
        Instantiate(Player, transformPlayerSpawn.position, transformPlayerSpawn.rotation);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthNPoints>().IsInvincible = true;
        isSpawnCooldown = false;
        Invoke("disableInvincibility", 5f);
    }

    void disableInvincibility()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthNPoints>().IsInvincible = false;
    }
}
