using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RegionDetector : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            Debug.Log(this.name +other.gameObject.name);
            DisplayPlayer1Reg.region = this.name;
            //DisplayPlayer1Reg.region = this.name;
        }
        else
        {
            Debug.Log(this.name + other.gameObject.name);
            DisplayPlayer2Reg.region = this.name;
           // DisplayPlayer2Reg.region = this.name;
        }
        
    }
}
