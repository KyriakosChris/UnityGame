using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    // Collider of the MoneyPassthrough, Give the player money and play a sound.
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
