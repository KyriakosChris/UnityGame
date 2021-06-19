using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
public class Rules : MonoBehaviour
{
    /*
     This is the script that controls the flow of the game. Here there is an enumaration with states of the game that control which script is running each time.
     There are also some public static variables that set some conditions.
     */
    public enum MyEnum
    {
        INIT,
        ROLL_DICE,
        SHOW_DICE,
        MOVE_PLAYER,
        CHECK_NODE,
        ACTION_OF_NODE,
        BUY_NODE,
        CHOOSE_REGION,
        WAITING,
        ROLL_BUILDDICE,
        ACTION_BUILDDICE,
        CHECK_MONEY,
        END_TURN,
        FREE_BUILD,
        FREE_ENTRANCE,
        CHOOSE_REGION_NODE,
        ENTRANCE_POINT,
        PAY,
        GAME_OVER
    }

    public static bool Roll1DicePerTurn;
    public static int Turn_Counter;
    public static int P1Money;
    public static int P2Money;
    public static int CostToBuy = 1000;
    public static int CostToBuild = 200;
    public static int EntryCost = 100;
    public static int OverNight = 50;
    public static int[,] Owners = new int[8,5];
    public static string CurrentPlayerNode;
    public static MyEnum states = MyEnum.INIT;
    public static string DiceChoose = "Normal Dice";
    public static bool PlayerEntrancePoint;
    public static bool Pay;
    public static string cam;
    public static string Winner;


    // Change the main camera to a ViewMap camera, to see all the map while building.
    public static void CamChange()
    {


        if (cam == InitVars.cam1.name)
        {
            InitVars.cam1.enabled = false;
            InitVars.cam2.enabled = true;
            cam = InitVars.cam2.name;
        }
        else
        {
            InitVars.cam1.enabled = true;
            InitVars.cam2.enabled = false;
            cam = InitVars.cam1.name;
        }
    }

    // Check if a player has negative amount of money. If he has he loose.
    public static void Checkmoney()
    {
        int money;
        if (TurnManager.GetInstance().GetCurrentPlayer().ToString().Equals("Player 1"))
        {
            //Debug.Log("P1 "+TurnManager.GetInstance().GetCurrentPlayer().ToString());
            money = P1Money;
        }
        else
        {
            //Debug.Log("P2 " + TurnManager.GetInstance().GetCurrentPlayer().ToString());
            money = P2Money;
        }
        //Debug.Log("Turn player  " + TurnManager.GetInstance().GetCurrentPlayer().ToString() + "  Winner " + Turn_Counter + "  is " + Winner +" money  "+ money);
        if (money < 0)
        {

            states = MyEnum.GAME_OVER;
            
        }
        else if (!PlayerEntrancePoint)
        {
            states = MyEnum.END_TURN;
            
        }
        else
            states = MyEnum.CHECK_NODE;
    }


    // Convert the Name of the region to a RegionNumber.
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


}
