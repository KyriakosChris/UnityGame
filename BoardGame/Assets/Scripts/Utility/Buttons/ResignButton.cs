using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResignButton : MonoBehaviour
{
    // Concide Button
    public void Resign()
    {
        
        if (TurnManager.GetInstance().GetCurrentPlayer().ToString().Equals("Player 1"))
        {
            
            Rules.Winner = "Player 2";
        }
        else
        {
            
            Rules.Winner = "Player 1";
        }

        Rules.states = Rules.MyEnum.GAME_OVER;
    }
}
