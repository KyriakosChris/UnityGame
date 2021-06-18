using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    
    int p; // player Number

    // Update is called once per frame
    void Update()
    {

        // Setting up the Results of the build dice before build
        if (Rules.states == Rules.MyEnum.ACTION_BUILDDICE)
        {
            
            if (DiceCheckZoneScript.BuildDice == "Red")
            {
                Rules.states = Rules.MyEnum.CHECK_MONEY;

                //Debug.Log("Building Rejected");
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
            //Debug.Log("Building  for: "+ Rules.CostToBuild);

            // The player Build the houses that he chose
            CanBuild(turn);

        }
    }

    /* If the player Can Build, firsts checks what region the player chose from the dropdown menu. If it was not null, and he hasnt already build all the houses at this region
     * He builds as many houses as he can from the number of houses that he chose. The cost of the houses is already fixed from the build Dice. If after a build he has negative amount of money,
     * he loses.
     * */
    public void CanBuild(string turn)
    {

        int region = Rules.RegionNumber(DropdownMenu.RegionSelector);
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
                FindObjectOfType<AudioManager>().Stop("BuildSound");
                FindObjectOfType<AudioManager>().Play("BuildSound");
               // Debug.Log("Set Active region "+ region + 1+" House "+j);
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
