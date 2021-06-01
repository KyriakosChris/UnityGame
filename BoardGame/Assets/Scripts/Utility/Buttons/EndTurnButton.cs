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

    }
}
