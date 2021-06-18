using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndTurnButton : MonoBehaviour
{

    public void EndTurn()
    {
        // Close All the button exept rollDice, to avoid bugs at the start of each turn
        TurnManager.GetInstance().EndTurn();
        Rules.Turn_Counter++;
        InitVars.RollDice.SetActive(true);
        InitVars.Buybutton.SetActive(false);
        InitVars.Regiondropdown.SetActive(false);
        InitVars.Endturn.SetActive(false);
        InitVars.Buildbutton.SetActive(false);
        InitVars.Inputfield.SetActive(false);
        InitVars.Buybutton.SetActive(false);
        InitVars.EnterButton.SetActive(false);
        InitVars.Resign.SetActive(true);
        Rules.Pay = false;
        Rules. CamChange();

        // Delete all messages at the end of the turn.
        InitVars.Messages.GetComponent<TextMeshProUGUI>().text = null;
    }
}
