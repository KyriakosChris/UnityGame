using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RollDice6 : MonoBehaviour
{

    
    public void RollDice_6()
    {
        Rules.states = Rules.MyEnum.ROLL_DICE;
    }


    public void RollDice_Build()
    {
        Rules.states = Rules.MyEnum.ROLL_BUILD_DICE;
    }

}
