using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pay : MonoBehaviour
{
    public static int numOfBuilding;

    // Update is called once per frame
    void Update()
    {
        if(Rules.states == Rules.MyEnum.PAY)
        {
            int cost = DiceCheckZoneScript.diceNumber * Rules.OverNight * numOfBuilding;
            string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
            if (turn == "Player 1")
            {
                Rules.P1Money-=cost;
            }
            else
            {
                Rules.P2Money -= cost;
            }
            InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You Paid "+ cost + " $";
            Buy.Checkmoney();
        }
    }
}
