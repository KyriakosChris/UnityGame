using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    // Start is called before the first frame update
    int p;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Rules.states.ToString());


        if (Rules.states == Rules.MyEnum.ACTION_BUILDDICE)
        {
            if (DiceCheckZoneScript.BuildDice == "Red")
            {
                Debug.Log("Building Rejected");
                return;
            }
            Rules.states = Rules.MyEnum.CHECK_MONEY;
            string turn = TurnManager.getInstance().getCurrentPlayer().ToString();
            //GameObject player = GameObject.FindGameObjectWithTag(turn);
            if (turn.Equals("Player 1"))
            {
                p = 1;
            }
            else
            {
                p = 2;
            }
            if (DiceCheckZoneScript.BuildDice == "H")
            {
                Rules.CostToBuild = 0;
            }
            if (DiceCheckZoneScript.BuildDice == "2")
            {
                Rules.CostToBuild *= 2;
            }
            Debug.Log("Building  for: "+ Rules.CostToBuild);
            CanBuild(turn);


            
        }
    }

    public void CanBuild(string turn)
    {
        string own="";
        for (int i = 0; i < 8; i++)
        {
            own += Rules.Owners[i, 0].ToString()+" ";
            for (int j = 1; j < 5; j++)
            {
                if (Rules.Owners[i, j] == 0 && p == Rules.Owners[i, 0] && InputScript.houseNumber > 0) // if a player has an area and has not build yet, he can build
                {
                    // He will build in the firsts availables places
                    
                    Rules.Owners[i, j] = 1;
                    InputScript.houseNumber--;
                    Transform childs = GameObject.Find("Regions").GetComponentInChildren<Transform>();
                    childs.GetChild(i).GetChild(j-1).gameObject.SetActive(true);
                    childs.GetChild(i).GetChild(j - 1).Find("Entrance").gameObject.SetActive(false);
                    Debug.Log("Set Active region "+i+1+" House "+j);
                    if (turn.Equals("Player 1"))
                    {
                        Rules.P1Money -= Rules.CostToBuild;
                        if (Rules.P1Money < 0)
                        {
                            Rules.states = Rules.MyEnum.SELL_TO_SURVIVE;
                            Rules.CostToBuild = 200;
                            return;
                        }
                    }
                    else
                    {
                        Rules.P2Money -= Rules.CostToBuild;
                        if (Rules.P2Money < 0)
                        {
                            Rules.states = Rules.MyEnum.SELL_TO_SURVIVE;
                            Rules.CostToBuild = 200;
                            return;
                        }
                    }

                }
            }
        }
        Debug.Log(own);
        Rules.CostToBuild = 200;
    }
}
