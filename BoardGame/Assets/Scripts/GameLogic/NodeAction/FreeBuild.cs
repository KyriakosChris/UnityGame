using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeBuild : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        /*Check if a Player Selected a region from the dropdown, and if he hasnt build already all the houses, he build one for free.*/
        if (Rules.states == Rules.MyEnum.FREE_BUILD)
        {
            //Debug.Log("Free in  " + DropdownMenu.RegionSelector);

            string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
            int p;
            if (turn.Equals("Player 1"))
            {
                p = 1;
            }
            else
            {
                p = 2;
            }

            int region = Rules.RegionNumber(DropdownMenu.RegionSelector);
            if (region == -1)
            {
                Rules.states = Rules.MyEnum.END_TURN;
                return;
            }

            for (int j = 1; j < 5; j++)
            {
                // 0 if has nothing, 2 if he has only entrance
                if ((Rules.Owners[region, j] == 0 || Rules.Owners[region, j] == 2) && p == Rules.Owners[region, 0]) // if a player has an area and has not build yet, he can build
                {
                    // He will build in the first available place
                    Rules.Owners[region, j] += 1;
                    Transform childs = GameObject.Find("Regions").GetComponentInChildren<Transform>();
                    childs.GetChild(region).GetChild(j - 1).gameObject.SetActive(true);

                    FindObjectOfType<AudioManager>().Stop("BuildSound");
                    FindObjectOfType<AudioManager>().Play("BuildSound");

                    //Debug.Log("Set Active region " + (region + 1).ToString() + " House " + j);
                    //Debug.Log("Free Build was successful");
                    break;
                }
            }
            InitVars.Endturn.SetActive(true);
            Rules.states = Rules.MyEnum.END_TURN;
        }
    }
}
