using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Change the turn and the current player name.
 */
public class TurnManager
{
    #region Singleton
    private static TurnManager instance = null;
    public static TurnManager GetInstance()
    {
        if (instance == null)
        {
            return new TurnManager();
        }
        return instance;
    }

    #endregion
    TurnManager()
    {
        instance = this;
        players = new string[2];
        players[0] = "Player 1";
        players[1] = "Player 2";
        currentTurn = 0;
    }

    private readonly string[] players;
    private int currentTurn;


    public void EndTurn()
    {
        currentTurn++;
        if (currentTurn>players.Length-1)
        {
            currentTurn = 0;
        }
    }

    public string GetCurrentPlayer()
    {
        return players[currentTurn];
    }
}
