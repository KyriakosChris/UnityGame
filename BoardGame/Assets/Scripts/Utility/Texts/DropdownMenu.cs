using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropdownMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown dropdown;
    void Start()
    {
        dropdown.ClearOptions();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Rules.states == Rules.MyEnum.CHOOSE_REGION)
        RegionToBuild();
    }

    public void RegionToBuild()
    {

        dropdown.ClearOptions();
        string turn = TurnManager.getInstance().getCurrentPlayer().ToString();
        string own = "";
        int p;
        List<string> items = new List<string>();
        items.Add("Select Region");
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
                own += "Region " + i + 1;
                items.Add("Region " + (i+1).ToString());
                
            }
        }

        // Fill dropdown
        dropdown.AddOptions(items);
        //Print();
        dropdown.onValueChanged.AddListener(delegate { Print(); });
        //dropdown.gameObject.SetActive(false);
    }

    void Print()
    {
        int index = dropdown.value;
        Debug.Log(dropdown.value);
       
        if (index > 0)
        {
            Debug.Log(index);
        }
        Debug.Log(dropdown.options[index].text);
    }


}
