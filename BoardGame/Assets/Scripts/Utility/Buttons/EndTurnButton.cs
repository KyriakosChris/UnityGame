using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public Text turnText;
    public void EndTurn()
    {
        TurnManager.getInstance().EndTurn();
        turnText.text = TurnManager.getInstance().getCurrentPlayer();

    }
}
