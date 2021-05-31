using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager
{
    GameObject car1;
    GameObject car2;
    #region Singleton
    private static CarManager instance = null;
    public static CarManager getInstance()
    {
        if (instance == null)
        {
            return new CarManager();
        }
        return instance;
    }

    #endregion
    CarManager()
    {
        instance = this;
        car1 = GameObject.FindGameObjectWithTag("Player 1");
        car2 = GameObject.FindGameObjectWithTag("Player 2");
        
    }

    public void MoveToNext()
    {
        NodeList nodelist = GameObject.FindGameObjectWithTag("Inspector").GetComponent<NodeList>();


        if (TurnManager.getInstance().getCurrentPlayer().Equals("Player 1"))
        {
          
            car1.GetComponent<PlayerMove>().target = nodelist.nodes[car1.GetComponent<Player>().locationIndex % nodelist.nodes.Length].transform.position;
            car1.GetComponent<Player>().locationIndex++;
            

        }
        else
        {
            car2.GetComponent<PlayerMove>().target = nodelist.nodes[car2.GetComponent<Player>().locationIndex % nodelist.nodes.Length].transform.position;
            car2.GetComponent<Player>().locationIndex++;

        }
    }


}
