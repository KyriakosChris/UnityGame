using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
	public  Collider[] colliders;
	static Rigidbody rb;
	public static Vector3 diceVelocity;
	public static bool RollDice = false;
	public Camera Cam1, Cam2;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		diceVelocity = rb.velocity;

		if (RollDice && Rules.Roll1DicePerTurn)
		{
			//Cam1.enabled = false;
			//Cam2.enabled = true;
			RollDice = false;
			isTriggers(true);
			
			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range(0, 500);
			float dirY = Random.Range(0, 500);
			float dirZ = Random.Range(0, 500);
			transform.position = new Vector3(477, 12, 73);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 500);
			rb.AddTorque(dirX, dirY, dirZ);
		}
		if(Rules.Roll1DicePerTurn == false)
        {
			//Cam1.enabled = true;
			//Cam2.enabled = false;

		}
	}

	public  void isTriggers( bool onOff)
    {
		for(int i=0; i < 6; i++)
        {
			colliders[i].isTrigger = onOff;
        }
    }
}
