using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Buybutton()
    {
        Rules.WantsToBuy = true;
        Rules.states = Rules.MyEnum.BUY_NODE;
        InitVars.Buybutton.SetActive(false);
    }
}
