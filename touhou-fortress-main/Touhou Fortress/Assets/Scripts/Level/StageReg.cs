using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class StageReg : MonoBehaviour
{
    public int StageOneamountAtOnce;
    public int StageOneAmountTotal;
    public GameObject[] Enemy;
    public Transform SpawnPoint;

    private int cooldown = 10;
    private System.Timers.Timer timer;
    private int spawnTime;
    public int countSpawned = 0;

    public bool IsDone = false;

    //public StageReg(int stageamountonce, int stageamounttotal, GameObject[] enemies, Transform transform)
    //{
    //    StageOneamountAtOnce = stageamountonce;
    //    StageOneAmountTotal = stageamounttotal;
    //    Enemy = enemies;
    //    SpawnPoint = transform;
    //}

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < StageOneamountAtOnce && countSpawned < StageOneAmountTotal)
        {
            if (spawnTime == 0)
            {
                System.Random rand = new System.Random();
                Instantiate(Enemy[rand.Next(0, Enemy.Length)], SpawnPoint.position, SpawnPoint.rotation);
                countSpawned++;

                timer = new System.Timers.Timer();
                timer.Interval = 1000; // 1 second
                timer.Elapsed += new ElapsedEventHandler(timer1_Tick);
                spawnTime = cooldown;
                timer.Start();
            }
        }
        if (countSpawned == StageOneAmountTotal) IsDone = true;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        spawnTime--;
        if (spawnTime == 0)
        {
            timer.Stop();
        }
    }

}
