using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Vector3 target;
    public float speed;
    private void Start()
    {

        target = transform.position; // first target is starting Node.
    }

    // Here is the code that moves and rotates the player.
    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(this.transform.position, target) > 0.1f) // not equal, fixes some bugs.
            {
                
                NodeList nodelist = GameObject.FindGameObjectWithTag("Inspector").GetComponent<NodeList>();
                Vector3 movementDirection = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); // deltatime to move in real time not in fps time.
                transform.position = movementDirection;

                // The Player Always LooksAt the Next Node, to rotate more smoothly, still it can get smoothlier.
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
