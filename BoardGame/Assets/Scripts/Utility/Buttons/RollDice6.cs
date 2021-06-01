using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RollDice6 : MonoBehaviour
{

    
    public void rollDice()
    {
        Rules.states = Rules.MyEnum.ROLL_DICE;
    }

}
