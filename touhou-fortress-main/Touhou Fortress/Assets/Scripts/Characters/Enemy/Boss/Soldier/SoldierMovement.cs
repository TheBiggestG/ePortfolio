using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoldierMovement : MonoBehaviour
{
    public List<GameObject> WayPoints;
    public float speed;

    private int ListAmount;
    public float WaitCoolDown;
    private byte selectedNumb;
    protected bool readyToMove = true;
    protected System.Random rand = new System.Random();

    protected Vector3 randomPosition;

    private void Start()
    {
        ListAmount = WayPoints.Count;

        randomPosition = new Vector3(0,0,0);
        MoveStep();
    }

    private void Update()
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

    private void EnableNextStep()
    {
        selectedNumb = (byte)(rand.Next(1, ListAmount) - 1);
        randomPosition = WayPoints[selectedNumb].gameObject.transform.position;
        readyToMove = true;
    }

    private void startNextStep()
    {
        readyToMove = false;
        Invoke("EnableNextStep", WaitCoolDown);
    }

}
