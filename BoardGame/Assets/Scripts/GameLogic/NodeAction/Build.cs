using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    // Start is called before the first frame update
    string reg;
    int p;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rules.states == Rules.MyEnum.ACTION_BUILDDICE)
        {
            if (DiceCheckZoneScript.BuildDice == "Red")
            {
                Debug.Log("Building Rejected");
                return;
            }
            string turn = TurnManager.getInstance().getCurrentPlayer().ToString();
            GameObject player = GameObject.FindGameObjectWithTag(turn);
            if (turn.Equals("Player 1"))
            {
                p = 1;
            }
            else
            {
                p = 2;
            }
            if (CanBuild(turn, player))
            {

            }
        }
    }

    public bool CanBuild(string turn, GameObject player)
    {
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 1; j < 5; j++)
            {
                if (Rules.Owners[i, j] == 0 && p == Rules.Owners[i, 0]) // if a player has an area and has not build yet, he can build
                {
                    // He will build in the first available place

                    return true;
                }
            }
        }
        return false;


    }
}
