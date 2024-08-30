using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MasterSpawnScript : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject MiniBoss;
    public GameObject MainBoss;

    private int StageNumber = 1;
    private bool IsBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (!IsBusy)
        {
            switch (StageNumber)
            {
                case 1:
                    if (GetComponent<StageReg>().IsDone)
                    {
                        Debug.Log("Stage 1 complete");
                        Debug.Log("Sleep 1");
                        IsBusy = true;
                        Invoke("AdvanceRegStage", 10f);
                        Debug.Log("Wake 1");
                    }
                    break;
                case 2:
                    if (GetComponent<StageReg>().IsDone)
                    {
                        Debug.Log("Stage 2 complete");

                        GetComponent<StageReg>().enabled = false;
                        IsBusy = true;
                        Debug.Log("Sleep 2");
                        Invoke("InstantiateObjectMiniBoss", 10f);
                        Debug.Log("Wake 2");
                    }
                    break;
                case 3:
                    if (GameObject.FindGameObjectWithTag("MiniBoss") == null)
                    {
                        StageNumber++;
                        Debug.Log("Stage 3 complete");
                    }
                    break;
                case 4:
                    if (GetComponent<StageReg>().IsDone)
                    {
                        Debug.Log("Stage 4 complete");

                        GetComponent<StageReg>().enabled = false;
                        IsBusy = true;
                        Debug.Log("Sleep 4");
                        Invoke("AdvanceRegStage", 10f);
                        Debug.Log("Wake 4");
                    }
                    break;
                    case 5:
                    if (GetComponent<StageReg>().IsDone)
                    {
                        Debug.Log("Stage 4 complete");

                        GetComponent<StageReg>().enabled = false;
                        IsBusy = true;
                        Debug.Log("Sleep 4");
                        Invoke("AdvanceRegStage", 10f);
                        Debug.Log("Wake 4");
                    }
                    break;
            }
        }
    }

    private void AdvanceRegStage()
    {
        Debug.Log("advance");

        GetComponent<StageReg>().StageOneamountAtOnce = 1;
        GetComponent<StageReg>().StageOneAmountTotal = 1;
        GetComponent<StageReg>().countSpawned = 0;
        GetComponent<StageReg>().IsDone = false;
        StageNumber++;
        IsBusy = false;
    }

    private void InstantiateObjectMiniBoss()
    {
        Instantiate(MiniBoss, transform);
        StageNumber++;
        IsBusy = false;
    } 
}
