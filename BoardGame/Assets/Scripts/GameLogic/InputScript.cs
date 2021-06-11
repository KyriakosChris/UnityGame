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

        if (int.TryParse(GameObject.Find("HousesToBuild/Text").GetComponent<Text>().text, out houseNumber))
        {
            Debug.Log("String is the number: " + houseNumber);
            Rules.states = Rules.MyEnum.BUILD_NODE;
            InitVars.Buildbutton.SetActive(true);
            GameObject.Find("HousesToBuild/Text").GetComponent<Text>().text = "";
            InitVars.Inputfield.SetActive(false);
            
        }
        else
        {
            GameObject.Find("HousesToBuild/ErrorMsg").GetComponent<Text>().text = "The input must be an integer, try again";
        }

        
        Debug.Log("houseNumber : " + houseNumber);
    }
}
