using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeavyUIState : MonoBehaviour
{
    public Material originalMat;
    public Material specialMat;
    public PlayerStats playerUlt;
    private bool IsSpecialState = false;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>().isOnUlt == true && IsSpecialState == false)
        {
            gameObject.GetComponent<Image>().material = specialMat;
            IsSpecialState= true;
        }
        else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>().isOnUlt == false && IsSpecialState == true)
        {
            gameObject.GetComponent<Image>().material = originalMat;
            IsSpecialState = false;
        }
    }
}
