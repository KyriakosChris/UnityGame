using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int houseNumber;

    public void GetInput()
    {

        if (Rules.CurrentPlayerNode.Equals("Free Build Node"))
        {
           
            Rules.states = Rules.MyEnum.FREE_BUILD;
            InitVars.Regiondropdown.SetActive(false);
            InitVars.EnterButton.SetActive(false);
            //Debug.Log(DropdownMenu.RegionSelector + " With State "+ Rules.states);
        }
        else if (int.TryParse(GameObject.Find("HousesToBuild/Text").GetComponent<Text>().text, out houseNumber))
        {
           // Debug.Log("String is the number: " + houseNumber);
            InitVars.Regiondropdown.SetActive(false);
            Rules.states = Rules.MyEnum.WAITING;
            InitVars.Buildbutton.SetActive(true);
            GameObject.Find("HousesToBuild/Text").GetComponent<Text>().text = "";
            InitVars.Inputfield.SetActive(false);
            InitVars.EnterButton.SetActive(false);

        }
        else
        {
            GameObject.Find("HousesToBuild/ErrorMsg").GetComponent<Text>().text = "The input must be an integer, try again";
        }

        
       // Debug.Log("houseNumber : " + houseNumber);
    }
}
