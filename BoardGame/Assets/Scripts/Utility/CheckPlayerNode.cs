using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerNode : MonoBehaviour
{
    // Start is called before the first frame update
    NodeList nodelist;
    GameObject player;
    string turn;
    void Start()
    {
        nodelist = GameObject.FindGameObjectWithTag("Inspector").GetComponent<NodeList>();
    }

    // Update is called once per frame
    void Update()
    {
        turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
        player = GameObject.FindGameObjectWithTag(turn);



        if (Rules.states == Rules.MyEnum.CHECK_NODE)
        {


            if (Rules.PlayerEntrancePoint)
            {
                Debug.Log("Happend: " + Rules.states);
                InitVars.Regiondropdown.SetActive(true);
                Rules.states = Rules.MyEnum.CHOOSE_REGION_NODE;
                return;
            }



            
            Rules.CurrentPlayerNode = nodelist.nodes[(player.GetComponent<Player>().locationIndex - 1) % nodelist.nodes.Length].name;

            if (MustPay(TurnManager.GetInstance().GetCurrentPlayer().ToString()))
            {
                Rules.states = Rules.MyEnum.WAITING;
                InitVars.RollDice.SetActive(true);
                Rules.Roll1DicePerTurn = true;
                return;
            }

            Rules.states = Rules.MyEnum.ACTION_OF_NODE;
            if (Rules.CurrentPlayerNode.Equals("Build Node"))
            {
                Rules.states = Rules.MyEnum.CHOOSE_REGION;
                InitVars.Regiondropdown.SetActive(true);

            }
            else if (Rules.CurrentPlayerNode.Equals("Buy Node"))
            {
                InitVars.Buybutton.SetActive(true);
                InitVars.Endturn.SetActive(true);
            }
            else if (Rules.CurrentPlayerNode.Equals("Free Build Node"))
            {
                Rules.states = Rules.MyEnum.CHOOSE_REGION;
                InitVars.Regiondropdown.SetActive(true);
            }
            else if (Rules.CurrentPlayerNode.Equals("Free Entrance Node"))
            {
                Rules.states = Rules.MyEnum.CHOOSE_REGION_NODE;
                InitVars.Regiondropdown.SetActive(true);
            }
            else {
                // Decor Nodes do nothing
                Rules.states = Rules.MyEnum.END_TURN;
            }
        }
        
        
    }
    public bool MustPay(string player)
    {
        string reg;
        int index,p;
        Rules.Pay = false;
        Pay.numOfBuilding = 0;
        NodeList nodelist = GameObject.FindGameObjectWithTag("Inspector").GetComponent<NodeList>();
        if (player == "Player 1")
        {
            reg = DisplayPlayer1Reg.region;
            index = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Player>().locationIndex-1;
            p = 1;
        }
        else
        {
            reg = DisplayPlayer2Reg.region;
            index = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Player>().locationIndex-1;
            p = 2;

        }

        int CurrentPlayerRegion = Buy.RegionNumber(reg);

        Debug.Log("Index "+index);
        Debug.Log("CurrentPlayerRegion:  "+ CurrentPlayerRegion +"  When "+ reg + " Node  "+ nodelist.nodes[(index) % nodelist.nodes.Length].name);
        if (Rules.Owners[CurrentPlayerRegion, 0] == 0)
            return Rules.Pay;

        string[] NodesWithEntrances = new string[5];
        for (int i = 1; i < 5; i++)
        {
            if (Rules.Owners[CurrentPlayerRegion, i] > 1)
            {
                
                NodesWithEntrances[i] = nodelist.nodes[i].name;
                Debug.Log(NodesWithEntrances[i]);
            }
        }
        
            for (int i = 1; i< 5; i++)
        {
            // The region belongs to the other player and has entrance at the node that the player is.
            if(Rules.Owners[CurrentPlayerRegion,0] != p && Rules.Owners[CurrentPlayerRegion, i] >1 && nodelist.nodes[(index) % nodelist.nodes.Length].name == NodesWithEntrances[i])
            {
                Debug.Log("PAYTIME   "+"CurrentPlayerRegion:  " + CurrentPlayerRegion + "  When " + reg + " Node  " + nodelist.nodes[(index) % nodelist.nodes.Length].name);
                Rules.Pay = true;
                
            }
            // Count The number of building in the Region
            if (Rules.Owners[CurrentPlayerRegion, i] == 1 || Rules.Owners[CurrentPlayerRegion, i] == 3)
                Pay.numOfBuilding++;
        }
        
        return Rules.Pay;
    }

}
