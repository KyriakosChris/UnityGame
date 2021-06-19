using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamChange : MonoBehaviour
{
    public GameObject  Cam1, Cam2, Cam3;
    // Changes the 3 cinemachine cameras. The 2 are for the players and one for the Dice. The way the cameras change is from the states of the game and the player turn.
    private void Update()
    {

        if (TurnManager.GetInstance().GetCurrentPlayer().Equals("Player 1") && Rules.states != Rules.MyEnum.SHOW_DICE)
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
        }
        if (TurnManager.GetInstance().GetCurrentPlayer().Equals("Player 2") && Rules.states != Rules.MyEnum.SHOW_DICE)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
        }

        if(Rules.states == Rules.MyEnum.SHOW_DICE)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(true);
        }
    }
}
