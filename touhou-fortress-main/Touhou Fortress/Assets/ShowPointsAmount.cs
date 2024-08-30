using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPointsAmount : MonoBehaviour
{
    public PlayerStats playerstats;
    public Text textElement;
    // Update is called once per frame
    void Update()
    {
        textElement.text = playerstats.Points.ToString();
    }
}
