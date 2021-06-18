using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResignButton : MonoBehaviour
{
    // Concide Button
    public void Resign()
    {
        Rules.states = Rules.MyEnum.GAME_OVER;
    }
}
