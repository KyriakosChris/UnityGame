using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RollDice : MonoBehaviour
{

    // Used for both dices.
    public void RollDice_6()
    {
        Rules.states = Rules.MyEnum.ROLL_DICE;
    }

    public void Roll_BuildDice()
    {
        Rules.states = Rules.MyEnum.ROLL_BUILDDICE;
    }

}
