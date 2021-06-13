using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{

    public void EndTurn()
    {
        TurnManager.GetInstance().EndTurn();
        Rules.Turn_Counter++;
        InitVars.Endturn.SetActive(true);
        InitVars.RollDice.SetActive(true);
        InitVars.Buybutton.SetActive(false);
        InitVars.Regiondropdown.SetActive(false);
    }
}
