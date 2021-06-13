using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            Rules.PlayerEntrancePoint = 1;
        }
        else
        {
            Rules.PlayerEntrancePoint = 2;
        }
        Debug.Log(Rules.PlayerEntrancePoint);
    }
}
