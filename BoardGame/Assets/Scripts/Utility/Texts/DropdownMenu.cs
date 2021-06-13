using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropdownMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static string RegionSelector;
    public static string EntrancePosition;
    // Update is called once per frame
    void Update()
    {
        
        
        if (Rules.states == Rules.MyEnum.CHOOSE_REGION)
        {

            Dropdown dropdown = InitVars.Regiondropdown.GetComponent<Dropdown>();
            
            RegionToBuild(dropdown);
            

            Rules.states = Rules.MyEnum.WAITING;

        }

        if (Rules.states == Rules.MyEnum.CHOOSE_REGION_NODE)
        {

            Dropdown dropdown = InitVars.Regiondropdown.GetComponent<Dropdown>();
            ChooseEntrancePossition(dropdown);
            Rules.states = Rules.MyEnum.WAITING;

        }
    }
    public void ChooseEntrancePossition(Dropdown dropdown)
    {
        dropdown.ClearOptions();
        string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
        int p;
        List<string> items = new List<string>
        {
            "Select Position in Region"
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
            bool houseInRegion = false;
           
            if (p == Rules.Owners[i, 0]) // Check the owned regions by the player only
            {
                // Check if at least a house exist in the Region in order to build an entrance 
                for (int j = 1; j < 5; j++)
                {
                    if (Rules.Owners[i, j] > 0) {
                        houseInRegion = true;
                        break;
                    }

                }

                if (houseInRegion)
                {
                    houseInRegion = false;
                    for (int j = 1; j < 5; j++)
                    {
                        if (Rules.Owners[i, j] < 2) // It means that this node has not an entrance yet
                        {
                            items.Add("Region " + (i + 1).ToString()+",Position "+j);
                        }

                    }
                }
            }
        }
        // Fill dropdown
        dropdown.AddOptions(items);
        //Print();
        dropdown.onValueChanged.AddListener(delegate { EntrancePosition = dropdown.options[dropdown.value].text; });
        // If we dont have where to build end turn
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
    public void RegionToBuild(Dropdown dropdown)
    {

        dropdown.ClearOptions();
        string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
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
        dropdown.onValueChanged.AddListener(delegate { RegionSelector = dropdown.options[dropdown.value].text; });
        // If we dont have where to build end turn
        if (items.Count <= 1)
        {
            InitVars.Regiondropdown.SetActive(false);
            Rules.states = Rules.MyEnum.END_TURN;
        }
        else
        {
            if (!Rules.CurrentPlayerNode.Equals("Build Node"))
            {
                InitVars.Inputfield.SetActive(true);
            }
            InitVars.EnterButton.SetActive(true);
        }
    }


}
