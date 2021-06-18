using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* Init all the gameObject that are not decor to visible or invisible at the start of the game. Here also init and some useful variables and arrays. */
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
    public static GameObject Resign;
    public static Camera cam1;
    public static Camera cam2;
    void Awake()
    {
        // The Reset helps for restart game
        if (Rules.states == Rules.MyEnum.INIT)
        {
            // Init All the buttons
            Buildbutton = GameObject.Find("BuildDiceRoll");
            RollDice = GameObject.Find("RollDiceButton");
            Endturn = GameObject.Find("EndTurnButton");
            Buybutton = GameObject.Find("BuyButton");
            Inputfield = GameObject.Find("HousesToBuild");
            Regiondropdown = GameObject.Find("ListOfRegion");
            EnterButton = GameObject.Find("EnterButton");
            Messages = GameObject.Find("MessagesToShow");
            Resign = GameObject.Find("ResignButton");
            Inputfield.SetActive(false);
            Messages.SetActive(true);
            Resign.SetActive(true);
            EnterButton.SetActive(false);
            Regiondropdown.SetActive(false);
            Buildbutton.SetActive(false);
            Buybutton.SetActive(false);
            Endturn.SetActive(false);
            Regiondropdown.GetComponent<TMP_Dropdown>().ClearOptions();

            // Init cameras

            cam1 =GameObject.Find("Player_camera").GetComponent<Camera>();
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

                }
                

            }
               
        }
        
        // Reset Owners Array
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Rules.Owners[i, j] = 0;
            }
        }

        // Reset some Variables
        Rules.P1Money = 2500;
        Rules.P2Money = 2500;
        Rules.Turn_Counter = 1;
        Rules.Roll1DicePerTurn = true;

    }
}
