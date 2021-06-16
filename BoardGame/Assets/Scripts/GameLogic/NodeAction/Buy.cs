using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;
public class Buy : MonoBehaviour
{

    public GameObject NameRegion;
    public Renderer ren;
    string reg;
    void Update()
    {
        if (Rules.states == Rules.MyEnum.BUY_NODE)
        {
            BuyNode();
            Checkmoney();
        }
    }

    public static void Checkmoney()
    {
        int money;
        if (TurnManager.GetInstance().GetCurrentPlayer().ToString().Equals("Player 1"))
            money = Rules.P1Money;
        else
            money = Rules.P2Money;
            if (money < 0)
            {
                Rules.states = Rules.MyEnum.GAME_OVER; 
            }
            else
            {
                Rules.states = Rules.MyEnum.END_TURN;
            }
    }
    public void BuyNode()
    {
        Rules.states = Rules.MyEnum.CHECK_MONEY;
        string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
        int index;

        if (turn == "Player 1")
        {
            reg = DisplayPlayer1Reg.region;
        }
        else
        {
            reg = DisplayPlayer2Reg.region;
            
        }
        index = RegionNumber(reg);
        if (Rules.Owners[index,0] == 0)
        {
            NormalBuyNode(turn, index);
        }
        else if (!turn.EndsWith(Rules.Owners[index,0].ToString()))
        {
            SellNode(turn, index);
        }

    }

    public static int RegionNumber(string reg)
    {
        if (reg == null)
            return -1;
        string[] digits = Regex.Split(reg, @"\D+");
        foreach (string value in digits)
        {
           
            if (int.TryParse(value, out int number))
            {
                return number - 1;
            }
        }
        return -1;
    }

    public void SellNode(string turn, int index)
    {
        bool check = true;

        for (int i =1; i<5; i++)
        {
            if (Rules.Owners[index, i] != 0)
            {
                check = false;
                break;
            }
        }
        if (check)
        {
            if (turn.Equals("Player 1"))
            {
                if (Rules.P1Money < Rules.CostToBuy / 2)
                {
                    InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You don't have the money to buy it.";
                    return;
                }
                Rules.P1Money -= Rules.CostToBuy / 2;
                Rules.P2Money += Rules.CostToBuy / 2;
                ColorTheRegion(1); // 1 for red 

            }
            else
            {
                if (Rules.P2Money < Rules.CostToBuy / 2)
                {
                    InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You don't have the money to buy it.";
                    return;
                }
                Rules.P2Money -= Rules.CostToBuy / 2;
                Rules.P1Money += Rules.CostToBuy / 2;
                Rules.Owners[index, 0] = 2;
                ColorTheRegion(0); // 1 for black 
            }
        }
        else
        {
            InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You can't buy this Region anymore.";
            InitVars.Buybutton.SetActive(false);
        }
    }
    

    public  void NormalBuyNode(string turn,int index)
    {
        if (turn.Equals("Player 1"))
        {
            if (Rules.P1Money < Rules.CostToBuy)
            {
                InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You don't have the money to buy it.";
                return;
            }
            Rules.P1Money -= Rules.CostToBuy;
            Rules.Owners[index,0] = 1;
            ColorTheRegion(1); // 1 for red 
        }
        else
        {
            if (Rules.P2Money < Rules.CostToBuy)
            {
                InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You don't have the money to buy it.";
                
                return;
            }
            Rules.P2Money -= Rules.CostToBuy;
            Rules.Owners[index,0] = 2;
            ColorTheRegion(0); // 1 for black 
        }
        
    }
    public void ColorTheRegion(float color)
    {
        reg += "/Name";
        NameRegion = GameObject.Find(reg);
        Transform allchildren = NameRegion.transform.GetComponentInChildren<Transform>();
        //Debug.Log(allchildren.childCount);
        for (int i = 0; i < allchildren.childCount; i++)
        {
            //Debug.Log(allchildren.GetChild(i).name);
            if (allchildren.GetChild(i).name.Contains("Prefab"))
            {
                if (allchildren.GetChild(i).name.Contains("_E") || allchildren.GetChild(i).name.Contains("_G"))
                    ren = allchildren.GetChild(i).GetChild(0).GetChild(1).GetComponent<Renderer>();
                else
                    ren = allchildren.GetChild(i).GetChild(0).GetComponent<Renderer>();
            }
            ren.material.color = new Color(color, 0, 0);
        }
    }


}
