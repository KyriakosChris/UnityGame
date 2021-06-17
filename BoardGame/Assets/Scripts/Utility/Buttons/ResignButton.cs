using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResignButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Resign()
    {
        Rules.states = Rules.MyEnum.GAME_OVER;
    }
}
