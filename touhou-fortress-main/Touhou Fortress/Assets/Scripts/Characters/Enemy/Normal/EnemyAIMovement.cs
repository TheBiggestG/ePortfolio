using System;
using UnityEngine;
using System.Timers;

public class EnemyAIMovement : MonoBehaviour
{

    public Vector3 targetPosition;
    public float WaitCoolDown;
    public int xMin, xMax, zMin, zMax;
    public float speed;

    protected bool readyToMove = true;
    protected Vector3 randomPosition;
    protected System.Random rand = new System.Random();

    private void Start()
    {
        randomPosition = targetPosition;
    }

    void Update()
    {
        MoveStep();
    }

    protected void MoveStep()
    {
            if (transform.position == randomPosition)
            {
                if (readyToMove)
                {
                    startNextStep();
                }

            }
            else //Superficial
            {
                transform.position = Vector3.MoveTowards(transform.position, randomPosition, speed);
            }
    }

    public void freezePos(bool toDisable)
    {
        if (toDisable) {
            randomPosition = transform.position;
            readyToMove = false;
        }
        else
        {
            EnableNextStep();
        }
    }

    private void EnableNextStep()
    {
        randomPosition = new Vector3(rand.Next(xMin, xMax), 1, rand.Next(zMin, zMax));
        readyToMove = true;
    }

    private void startNextStep()
    {
        readyToMove = false;
        Invoke("EnableNextStep", WaitCoolDown);
    }

}
