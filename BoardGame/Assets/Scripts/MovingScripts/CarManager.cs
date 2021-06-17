using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager
{
    private readonly GameObject car1;
    private readonly GameObject car2;
    #region Singleton
    private static CarManager instance = null;
    public static CarManager GetInstance()
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

        GameObject p1 = GameObject.FindGameObjectWithTag("Player 1");
        GameObject p2 = GameObject.FindGameObjectWithTag("Player 1");
        if (TurnManager.GetInstance().GetCurrentPlayer().Equals("Player 1"))
        {
            //Debug.Log("Size "+nodelist.nodes.Length);
            p1.GetComponent<PlayerMove>().target = nodelist.nodes[car1.GetComponent<Player>().locationIndex % nodelist.nodes.Length].transform.position;
            p1.GetComponent<Player>().locationIndex++;
            //Debug.Log("Car 1 Location "+car1.GetComponent<Player>().locationIndex);

        }
        else
        {
            p2.GetComponent<PlayerMove>().target = nodelist.nodes[car2.GetComponent<Player>().locationIndex % nodelist.nodes.Length].transform.position;
            p2.GetComponent<Player>().locationIndex++;
           // Debug.Log("Car 2 Location " + car2.GetComponent<Player>().locationIndex);
        }
    }


}
