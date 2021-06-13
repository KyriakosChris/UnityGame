using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropdownMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static string RegionSelector;

    // Update is called once per frame
    void Update()
    {
        
        
        if (Rules.states == Rules.MyEnum.CHOOSE_REGION)
        {

            Dropdown dropdown = InitVars.Regiondropdown.GetComponent<Dropdown>();
            
            RegionToBuild(dropdown);
            
            if (!Rules.CurrentPlayerNode.Equals("Free Build Node"))
            {
                InitVars.Inputfield.SetActive(true);
            }

            //dropdown.gameObject.SetActive(false);
            Rules.states = Rules.MyEnum.WAITING;

        }
    }

    public void RegionToBuild(Dropdown dropdown)
    {

        dropdown.ClearOptions();
        string turn = TurnManager.getInstance().getCurrentPlayer().ToString();
        int p;
        List<string> items = new List<string>
        {
            "Select Region"
        };
        if (turn.Equals("Player 1"))
        {
            p = 1;
        }
        else
        {
            p = 2;
        }
        for (int i = 0; i < 8; i++)
        {
            if (p == Rules.Owners[i, 0])
            {
                items.Add("Region " + (i+1).ToString());
                
            }
        }

        // Fill dropdown
        dropdown.AddOptions(items);
        //Print();
        dropdown.onValueChanged.AddListener(delegate { Print(dropdown); });

        if (items.Count <= 1)
        {
            InitVars.Regiondropdown.SetActive(false);
            Rules.states = Rules.MyEnum.END_TURN;
        }
        else
        {
            InitVars.EnterButton.SetActive(true);
        }
    }

    void Print(Dropdown dropdown)
    {
        int index = dropdown.value;
       // Debug.Log(dropdown.value);
        RegionSelector = dropdown.options[index].text;

        //Debug.Log(dropdown.options[index].text);
    }


}
