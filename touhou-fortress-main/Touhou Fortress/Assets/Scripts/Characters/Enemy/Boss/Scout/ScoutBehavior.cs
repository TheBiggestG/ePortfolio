using System;
using System.Timers;
using UnityEngine;


public class ScoutBehavior : MonoBehaviour
{
    public bool IsBusy = false;
    private EnemyAIMovement randomMovementScript;
    private ScoutChase followPlayerScript;
    private ScoutShoot scoutShootRef;
    private GameObject playerRef;

    private void Start()
    {
        randomMovementScript = GetComponent<EnemyAIMovement>();
        followPlayerScript = GetComponent<ScoutChase>();
        scoutShootRef = GetComponent<ScoutShoot>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        Invoke("StartFollowingPlayer", UnityEngine.Random.Range(5f, 10f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerRef)
        {
            ToggleFollowingPlayer();
            playerRef.GetComponent<PlayerMovement>().enabled = false;

            Invoke("EnablePlayerMovement", 10f);

            randomMovementScript.freezePos(false);
            followPlayerScript.enabled = false;
        }
    }
    private void EnablePlayerMovement()
    {
        playerRef.GetComponent<PlayerMovement>().enabled = true;
    }
    //Toggle
    private void ToggleFollowingPlayer()
    {
        IsBusy = !IsBusy;
        switch (/*UnityEngine.Random.Range(1, 3)*/2)
        {
            case 1:
                Debug.Log("Invoking soon StartFollowingPlayer");
                Invoke("StartFollowingPlayer", UnityEngine.Random.Range(1f, 2f));
                break;
            case 2:
                Debug.Log("Invoking soon StartSentryStage");
                Invoke("StartSentryStage", UnityEngine.Random.Range(10f, 12f));
                break;
            default:
                Debug.Log("Unity farted");
                break;
        }
    }
    //Follow
    private void StartFollowingPlayer()
    {
        randomMovementScript.freezePos(true);
        followPlayerScript.enabled = true;
        IsBusy = true;
    }
    //Sentry
    private void StartSentryStage()
    {
        randomMovementScript.freezePos(true);
        IsBusy = true;
        scoutShootRef.setShootingMode(0.5f, 20, 20);
        Invoke("StopSentryPhase", 10f);
    }
    private void StopSentryPhase()
    {
        scoutShootRef.resetShootingMode();
        randomMovementScript.freezePos(false);
        ToggleFollowingPlayer();
    }

}
