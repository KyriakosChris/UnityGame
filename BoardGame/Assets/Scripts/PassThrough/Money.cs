using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("CashOut");
        if (other.gameObject.CompareTag("Player 1"))
        {
            Rules.P1Money += 100;
        }
        else
        {
            Rules.P2Money += 100;
        }

    }
}
