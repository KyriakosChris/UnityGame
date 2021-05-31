using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamChange : MonoBehaviour
{
    public GameObject  Cam1, Cam2;

    private void Update()
    {
        if (TurnManager.getInstance().getCurrentPlayer().Equals("Player 1"))
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
        }
        if (TurnManager.getInstance().getCurrentPlayer().Equals("Player 2"))
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
        }
    }
}
