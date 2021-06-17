using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

            TMP_Dropdown dropdown = InitVars.Regiondropdown.GetComponent<TMP_Dropdown>();
            if(Rules.CurrentPlayerNode.Equals("Build Node"))
                InitVars.Inputfield.SetActive(true);

            RegionToBuild(dropdown);
            

            Rules.states = Rules.MyEnum.WAITING;

        }

        if (Rules.states == Rules.MyEnum.CHOOSE_REGION_NODE)
        {
            TMP_Dropdown dropdown = InitVars.Regiondropdown.GetComponent<TMP_Dropdown>();
            ChooseEntrancePossition(dropdown);
            

        }
    }
    public void ChooseEntrancePossition(TMP_Dropdown dropdown)
    {
        dropdown.ClearOptions();
        string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
        int p;
        List<string> items = new List<string>();
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
                int regionHouseNumber = 0;
                // Check if at least a house exist in the Region in order to build an entrance 
                for (int j = 1; j < 5; j++)
                {
                    if (Rules.Owners[i, j] > 0 ) {
                        houseInRegion = true;
                        
                    }
                    // If he has build all houses dont add this region to the list
                    if (Rules.Owners[i, j] == 1 || Rules.Owners[i, j] == 3)
                        regionHouseNumber++;

                }
                if (regionHouseNumber == 4)
                    houseInRegion = false;

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
        if (items.Count == 1)
        {
            RegionSelector = items[0];
        }


        // Fill dropdown
        dropdown.AddOptions(items);
        
        dropdown.onValueChanged.AddListener(delegate { EntrancePosition = dropdown.options[dropdown.value].text; });
        // If we dont have where to build end turn
        if (items.Count <= 0)
        {

            InitVars.Regiondropdown.SetActive(false);
            
            Rules.states = Rules.MyEnum.END_TURN;
            InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You can't Buy Entrys";
            if (Rules.PlayerEntrancePoint)
            {
                Debug.Log("Bug in Entry");
                Rules.states = Rules.MyEnum.CHECK_NODE;
                Rules.PlayerEntrancePoint = false;
                return;
            }
        }
        else
        {
            if (Rules.PlayerEntrancePoint)
            {
                if (turn.Equals("Player 1"))
                {
                    Rules.P1Money -= Rules.EntryCost;
                }
                else
                {
                    Rules.P2Money -= Rules.EntryCost;
                }

            }
            Rules.states = Rules.MyEnum.WAITING;
            InitVars.EnterButton.SetActive(true);
        }
       
    }
    public void RegionToBuild(TMP_Dropdown dropdown)
    {

        dropdown.ClearOptions();
        string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
        int p;
        List<string> items = new List<string>();
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
        if(items.Count == 1)
        {
            RegionSelector = items[0];
        }

        // Fill dropdown
        dropdown.AddOptions(items);
        //Print();
        dropdown.onValueChanged.AddListener(delegate { RegionSelector = dropdown.options[dropdown.value].text; });
        // If we dont have where to build end turn
        if (items.Count <= 0)
        {
            InitVars.Regiondropdown.SetActive(false);
            InitVars.Inputfield.SetActive(false);
            InitVars.Messages.GetComponent<TextMeshProUGUI>().text = "You can't Build Houses";
            Rules.states = Rules.MyEnum.END_TURN;
        }
        else
        {
            if (Rules.CurrentPlayerNode.Equals("Build Node"))
            {
                InitVars.Inputfield.SetActive(true);
            }
            InitVars.EnterButton.SetActive(true);
        }
    }


}
