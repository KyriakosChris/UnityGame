using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Rules.Checkmoney();
        }
    }


    /* Checks if the region that the player is now is avaliable for buying. Of courses if none of the players bought it, it is. 
     * The other case is if a player bought it, but has not build anything yet.
    */
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
        index = Rules.RegionNumber(reg);
        if (Rules.Owners[index,0] == 0)
        {
            NormalBuyNode(turn, index);
        }
        else if (!turn.EndsWith(Rules.Owners[index,0].ToString()))
        {
            SellNode(turn, index);
        }

    }

   

    /*If the player goes to a region that another player has already bought but hasnt build yet he can buy it from him for the half price.
    */
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
                Rules.Owners[index, 0] = 1;
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
                ColorTheRegion(0); // 0 for black 
            }
        }
        else
        {
            InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You can't buy this Region anymore.";
            InitVars.Buybutton.SetActive(false);
        }
    }
    
    /* If none player has this region he can buy it for the default price */
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
            ColorTheRegion(0); // 0 for black 
        }
        
    }
    /* After a player buy a region, it Changes the color of the region name. The new color is the color of the Owner-Player */
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
