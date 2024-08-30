using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowUltAmount : MonoBehaviour
{
    public PlayerStats playerstats;
    public Text textElement;
    // Update is called once per frame
    void Update()
    {
        textElement.text = playerstats.Ultimates.ToString();
    }
}
