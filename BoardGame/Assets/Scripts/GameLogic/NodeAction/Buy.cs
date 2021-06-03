using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{

    public static Renderer myrenderer;
    public Color redColor= new Color(1, 0, 0);
    public Color BlackColor = new Color(0,0,0);
    void Start()
    {
        myrenderer = gameObject.GetComponent<Renderer>();
    }
    void Update()
    {
        myrenderer.material.color = redColor;
    }
    public static void BuyNode()
    {
        Rules.states = Rules.MyEnum.BUY_NODE;
        string turn = TurnManager.getInstance().getCurrentPlayer().ToString();
        GameObject player = GameObject.FindGameObjectWithTag(turn);
        int index = player.GetComponent<Player>().locationIndex - 1;

        if (Rules.Owners[index] == 0)
        {
            NormalBuyNode(turn, index);
        }
        else if (!turn.EndsWith(Rules.Owners[index].ToString()))
        {
            SellNode(turn, index);
        }
        
        }
    public static void SellNode(string turn, int index)
    {
        if (turn.Equals("Player 1"))
        {
            Rules.P1Money -= Rules.CostToBuy / 2;
            Rules.P2Money += Rules.CostToBuy / 2;
            Rules.Owners[index] = 1;
        }
        else
        {
            Rules.P2Money -= Rules.CostToBuy / 2;
            Rules.P1Money += Rules.CostToBuy / 2;
            Rules.Owners[index] = 2;
        }
    }
    

    public static void NormalBuyNode(string turn,int index)
    {
        if (turn.Equals("Player 1"))
        {
            Rules.P1Money -= Rules.CostToBuy;
            Rules.Owners[index] = 1;
        }
        else
        {
            Rules.P2Money -= Rules.CostToBuy;
            Rules.Owners[index] = 2;
        }
        
    }

}
