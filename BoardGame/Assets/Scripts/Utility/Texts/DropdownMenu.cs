using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropdownMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static string RegionSelector;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Rules.states == Rules.MyEnum.CHOOSE_REGION)
        {
            Dropdown dropdown = InitVars.Regiondropdown.GetComponent<Dropdown>();
            RegionToBuild(dropdown);
            //dropdown.gameObject.SetActive(false);
            Rules.states = Rules.MyEnum.NUMBER_HOUSE;
            InitVars.Inputfield.SetActive(true);
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
        //dropdown.gameObject.SetActive(false);
    }

    void Print(Dropdown dropdown)
    {
        int index = dropdown.value;
        Debug.Log(dropdown.value);
        RegionSelector = dropdown.options[index].text;
        Debug.Log(dropdown.options[index].text);
    }


}
