using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Vector3 target;
    public float speed;
    private void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(this.transform.position, target) > 0.1f)
            {
                NodeList nodelist = GameObject.FindGameObjectWithTag("Inspector").GetComponent<NodeList>();
                Vector3 movementDirection = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                transform.position = movementDirection;
                if (TurnManager.GetInstance().GetCurrentPlayer().Equals("Player 1"))
                {
                    transform.LookAt(nodelist.nodes[GameObject.FindGameObjectWithTag("Player 1").GetComponent<Player>().locationIndex % nodelist.nodes.Length].transform.position);
                }
                else
                {
                    transform.LookAt(nodelist.nodes[GameObject.FindGameObjectWithTag("Player 2").GetComponent<Player>().locationIndex % nodelist.nodes.Length].transform.position);
                }
            }

        }
    }
}
