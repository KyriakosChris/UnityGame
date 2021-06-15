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



            Rules.states = Rules.MyEnum.ACTION_OF_NODE;
            Rules.CurrentPlayerNode = nodelist.nodes[(player.GetComponent<Player>().locationIndex - 1) % nodelist.nodes.Length].name;
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

}
