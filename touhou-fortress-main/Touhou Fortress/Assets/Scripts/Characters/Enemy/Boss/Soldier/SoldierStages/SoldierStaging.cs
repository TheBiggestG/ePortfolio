using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStaging : MonoBehaviour
{
    public GameObject BeggarShot;
    public GameObject DirectShot;

    private bool isBeggar = true;

    // Start is called before the first frame update
    void Start()
    {
        ChangeShot();
    }

    private void ChangeShot()
    {
        if (isBeggar)
        {
            GetComponent<EnemyGenericShot>().ShotProjectile = BeggarShot;
            isBeggar=false;
            Invoke("ChangeShot", 5);
        }
        else
        {
            GetComponent<EnemyGenericShot>().ShotProjectile = DirectShot;
            isBeggar = true;
            Invoke("ChangeShot", 5);
        }
    }
}
