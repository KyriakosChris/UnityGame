using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InitVars : MonoBehaviour
{

    // Update is called once per frame
    public static GameObject Buildbutton;
    public static GameObject RollDice;
    public static GameObject Endturn;
    public static GameObject Buybutton;
    public static GameObject Regions;
    public static GameObject Inputfield;
    public static GameObject Regiondropdown;
    public static GameObject EnterButton;
    public static GameObject Messages;
    public static Camera cam1;
    public static Camera cam2;
    void Awake()
    {
        if (Rules.states == Rules.MyEnum.INIT)
        {
            // Disable buttons
            Debug.Log("What");
            Buildbutton = GameObject.Find("BuildDiceRoll");
            RollDice = GameObject.Find("RollDiceButton");
            Endturn = GameObject.Find("EndTurnButton");
            Buybutton = GameObject.Find("BuyButton");
            Inputfield = GameObject.Find("HousesToBuild");
            Regiondropdown = GameObject.Find("ListOfRegion");
            EnterButton = GameObject.Find("EnterButton");
            Messages = GameObject.Find("MessagesToShow");
            Inputfield.SetActive(false);
            Messages.SetActive(true);
            EnterButton.SetActive(false);
            Regiondropdown.SetActive(false);
            Buildbutton.SetActive(false);
            Buybutton.SetActive(false);
            Endturn.SetActive(false);
            Regiondropdown.GetComponent<TMP_Dropdown>().ClearOptions();


            // Init cameras
            
            cam1=GameObject.Find("Player_camera").GetComponent<Camera>();
            cam2 = GameObject.Find("MapCamera").GetComponent<Camera>();
            cam1.enabled = true;
            cam2.enabled = false;
            Rules.cam = cam1.name;
            // Disable hotels
            Regions = GameObject.Find("Regions");
            Transform childs = Regions.GetComponentInChildren<Transform>();
            for (int i = 0; i < childs.childCount; i++)
            {
                for(int j = 0; j < childs.GetChild(i).childCount; j++)
                {
                    // Keep the name of each Region
                    if(!childs.GetChild(i).GetChild(j).gameObject.name.Equals("Name"))
                        childs.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    else
                    {
                        //Later set color to default for restart game
                    }

                }
                

            }
               
        }
        

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Rules.Owners[i, j] = 0;
            }
        }

        Rules.P1Money = 2500;
        Rules.P2Money = 2500;
        Rules.Turn_Counter = 1;
        Rules.Roll1DicePerTurn = true;

    }
}
