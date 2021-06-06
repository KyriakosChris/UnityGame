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
        turn = TurnManager.getInstance().getCurrentPlayer().ToString();
        player = GameObject.FindGameObjectWithTag(turn);
    }

    // Update is called once per frame
    void Update()
    {
        turn = TurnManager.getInstance().getCurrentPlayer().ToString();
        player = GameObject.FindGameObjectWithTag(turn);
        if (Rules.states == Rules.MyEnum.CHECK_NODE)
        {
            Rules.states = Rules.MyEnum.ACTION_OF_NODE;
            Rules.CurrentPlayerNode = nodelist.nodes[(player.GetComponent<Player>().locationIndex - 1) % nodelist.nodes.Length].name;
            if (Rules.CurrentPlayerNode == "Build Node")
            {
                Rules.states = Rules.MyEnum.BUILD_NODE;
                InitVars.Buildbutton.SetActive(true);
                
            }
            else if (Rules.CurrentPlayerNode == "Buy Node")
            {
                InitVars.Buybutton.SetActive(true);
                InitVars.Endturn.SetActive(true);
            }
        }
        
        
    }
}
