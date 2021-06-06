using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
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

    public void Checkmoney()
    {
        if (Rules.P1Money < 0)
        {
            Rules.states = Rules.MyEnum.GAME_OVER;  // To Do reset everythings
        }
        else
        {
            Rules.states = Rules.MyEnum.END_TURN;
            InitVars.Endturn.SetActive(true);
        }
    }
    public void BuyNode()
    {
        Rules.states = Rules.MyEnum.CHECK_MONEY;
        string turn = TurnManager.getInstance().getCurrentPlayer().ToString();
        GameObject player = GameObject.FindGameObjectWithTag(turn);
        int index;

        if (player.name == "Player_1")
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
        string[] digits = Regex.Split(reg, @"\D+");
        foreach (string value in digits)
        {
           
            if (int.TryParse(value, out int number))
            {
                return number - 1;
            }
        }
        return 0;
    }

    public void SellNode(string turn, int index)
    {
        bool check = false;
        for (int i =1; i<5; i++)
        {
            if (Rules.Owners[index, i] == 0)
            {
                check = true;
                break;
            }
        }
        if (check)
        {
            if (turn.Equals("Player 1"))
            {
                Rules.P1Money -= Rules.CostToBuy / 2;
                Rules.P2Money += Rules.CostToBuy / 2;
                ColorTheRegion(1); // 1 for red 

            }
            else
            {
                Rules.P2Money -= Rules.CostToBuy / 2;
                Rules.P1Money += Rules.CostToBuy / 2;
                Rules.Owners[index, 0] = 2;
                ColorTheRegion(0); // 1 for black 
            }
        }
    }
    

    public  void NormalBuyNode(string turn,int index)
    {
        if (turn.Equals("Player 1"))
        {
            Rules.P1Money -= Rules.CostToBuy;
            Rules.Owners[index,0] = 1;
            ColorTheRegion(1); // 1 for red 
        }
        else
        {
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
