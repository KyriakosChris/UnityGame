using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    // Button to Buy a Region
    public void Buybutton()
    {
        Rules.states = Rules.MyEnum.BUY_NODE;
        InitVars.Buybutton.SetActive(false);
    }
}
