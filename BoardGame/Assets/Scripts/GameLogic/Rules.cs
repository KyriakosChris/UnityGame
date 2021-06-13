using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        SELL_TO_SURVIVE,
        FREE_BUILD,
        FREE_ENTRANCE,
        CHOOSE_REGION_NODE,
        ENTRANCE_POINT,
        GAME_OVER
    }

    public static bool Roll1DicePerTurn;
    public static int Turn_Counter;
    public static int P1Money;
    public static int P2Money;
    public static int CostToBuy = 1000;
    public static int CostToBuild = 200;
    public static int OverNight = 100;
    public static int[,] Owners = new int[8,5];
    public static string CurrentPlayerNode;
    public static MyEnum states = MyEnum.INIT;
    public static string DiceChoose = "Normal Dice";
    public static int PlayerEntrancePoint;


}
