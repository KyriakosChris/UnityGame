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
        ACTION_OF_NODE
    }

    public static bool Roll1DicePerTurn = true;
    public static int Turn_Counter = 1;
    public static string CurrentPlayerNode;
    public static MyEnum states = MyEnum.INIT;


    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
