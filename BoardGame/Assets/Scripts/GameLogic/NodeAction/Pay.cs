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
        /* If the player has to pay, computes the cost that he has to pay, and if after the payment the player has negative amount of money Loses. */
        if(Rules.states == Rules.MyEnum.PAY)
        {
            int cost = DiceCheckZoneScript.diceNumber * Rules.OverNight * numOfBuilding;
            string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
            FindObjectOfType<AudioManager>().Play("CashOut");
            Rules.CamChange();
            if (turn == "Player 1")
            {
                Rules.P1Money-=cost;
                Rules.P2Money += cost;
            }
            else
            {
                Rules.P2Money -= cost;
                Rules.P1Money += cost;
            }
            InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You Paid "+ cost + " $";
            Rules.Checkmoney();

        }
    }
}
