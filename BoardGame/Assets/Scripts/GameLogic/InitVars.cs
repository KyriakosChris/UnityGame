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
    void Awake()
    {
        if (Rules.states == Rules.MyEnum.INIT)
        {
            Buildbutton = GameObject.FindGameObjectWithTag("Button Build Dice");
            RollDice = GameObject.FindGameObjectWithTag("Button Roll Dice");
            Endturn = GameObject.FindGameObjectWithTag("Button End Turn");
            Buybutton = GameObject.Find("BuyButton");
            Buildbutton.SetActive(false);
            Buybutton.SetActive(false);
            Endturn.SetActive(true);
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
