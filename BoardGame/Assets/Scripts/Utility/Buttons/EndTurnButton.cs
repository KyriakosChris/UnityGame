using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{

    public void EndTurn()
    {
        TurnManager.getInstance().EndTurn();
        Rules.Turn_Counter++;
        InitVars.Endturn.SetActive(true);
        InitVars.RollDice.SetActive(true);
        InitVars.Regiondropdown.SetActive(false);
    }
}
