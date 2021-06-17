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


        if (Rules.states == Rules.MyEnum.ACTION_BUILDDICE)
        {
            if (DiceCheckZoneScript.BuildDice == "Red")
            {
                Rules.states = Rules.MyEnum.CHECK_MONEY;

                Debug.Log("Building Rejected");
                return;
            }
            Rules.states = Rules.MyEnum.CHECK_MONEY;
            string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
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

        int region = Buy.RegionNumber(DropdownMenu.RegionSelector);
        DropdownMenu.RegionSelector = "";
        if (region == -1)
            return;
        for (int j = 1; j < 5; j++)
        {
            // 0 if has nothing, 2 if he has only entrance
            if ((Rules.Owners[region, j] == 0 || Rules.Owners[region, j] == 2) && p == Rules.Owners[region, 0] && InputScript.InputNumber > 0) // if a player has an area and has not build yet, he can build
            {
                // He will build in the firsts availables places
                    
                Rules.Owners[region, j] += 1;
                InputScript.InputNumber--;
                Transform childs = GameObject.Find("Regions").GetComponentInChildren<Transform>();
                childs.GetChild(region).GetChild(j-1).gameObject.SetActive(true);
                FindObjectOfType<AudioManager>().Play("BuildSound");
                //childs.GetChild(region).GetChild(j - 1).Find("Entrance").gameObject.SetActive(false);
                Debug.Log("Set Active region "+ region + 1+" House "+j);
                if (turn.Equals("Player 1"))
                {
                    Rules.P1Money -= Rules.CostToBuild;
                    if (Rules.P1Money < 0)
                    {
                        Rules.states = Rules.MyEnum.GAME_OVER;
                        Rules.CostToBuild = 200;
                        return;
                    }
                }
                else
                {
                    Rules.P2Money -= Rules.CostToBuild;
                    if (Rules.P2Money < 0)
                    {
                        Rules.states = Rules.MyEnum.GAME_OVER;
                        Rules.CostToBuild = 200;
                        return;
                    }
                }

            }
        }
        Rules.CostToBuild = 200;
    }
}
