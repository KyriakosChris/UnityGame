using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    // Collider of the EntrancePassthrough
    public void OnTriggerEnter(Collider other)
    {  
        Rules.PlayerEntrancePoint = true;
    }
}
