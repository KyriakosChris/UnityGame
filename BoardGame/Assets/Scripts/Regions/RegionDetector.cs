using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RegionDetector : MonoBehaviour
{

    // Detects the Current Region of the player.
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            DisplayPlayer1Reg.region = this.name;
        }
        else
        {
            DisplayPlayer2Reg.region = this.name;
        }
        
    }
}
