using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    public static bool Roll1DicePerTurn = true;
    
    public enum MyEnum
    {
        INIT,
        ROLL_DICE,
        SHOW_DICE,
        MOVE_PLAYER,
        CHECK_NODE,
        ACTION_OF_NODE
    }

    public static MyEnum states;

    void Awake()
    {
        states = MyEnum.INIT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
