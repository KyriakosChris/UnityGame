using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
public class Rules : MonoBehaviour
{

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


    public static void Checkmoney()
    {
        int money;
        if (TurnManager.GetInstance().GetCurrentPlayer().ToString().Equals("Player 1"))
            money = P1Money;
        else
            money = P2Money;
        if (money < 0)
        {
            states = MyEnum.GAME_OVER;
        }
        else
        {
            states = MyEnum.END_TURN;
        }
    }

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
