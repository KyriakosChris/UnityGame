using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitVars : MonoBehaviour
{

    // Update is called once per frame
    public static GameObject Buildbutton;
    public static GameObject RollDice;
    public static GameObject Endturn;
    public static GameObject Buybutton;
    public static GameObject Regions;
    public static GameObject Inputfield;

    void Awake()
    {
        if (Rules.states == Rules.MyEnum.INIT)
        {
            // Disable buttons
            Buildbutton = GameObject.Find("BuildDiceRoll");
            RollDice = GameObject.Find("RollDiceButton");
            Endturn = GameObject.Find("EndTurnButton");
            Buybutton = GameObject.Find("BuyButton");
            Inputfield = GameObject.Find("HousesToBuild");
            Inputfield.SetActive(false);
            Buildbutton.SetActive(false);
            Buybutton.SetActive(false);
            Endturn.SetActive(true);

            // Init cameras
            GameObject.Find("MapCamera").GetComponent<Camera>().enabled = false;
            GameObject.Find("Player1_camera").GetComponent<Camera>().enabled = true;
            // Disable hotels
            Regions = GameObject.Find("Regions");
            Transform childs = Regions.GetComponentInChildren<Transform>();
            for (int i = 0; i < childs.childCount; i++)
            {
                for(int j = 0; j < childs.GetChild(i).childCount; j++)
                {
                    // Keep the name of each Region
                    if(!childs.GetChild(i).GetChild(j).gameObject.name.Equals("Name"))
                        childs.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    else
                    {
                        //Later set color to default for restart game
                    }

                }
                

            }
               
        }
        

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Rules.Owners[i, j] = 0;
            }
        }
               Rules.P1Money = 2500;
        Rules.P2Money = 2500;
        Rules.Turn_Counter = 1;
        Rules.Roll1DicePerTurn = true;

    }


    void Update()
    {
        if(Rules.states == Rules.MyEnum.INIT)
        {
           
        }

        if (Rules.states == Rules.MyEnum.END_TURN)
        {
            Endturn.SetActive(true);
        }
    }
}
