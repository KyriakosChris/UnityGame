using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildDiceScript : MonoBehaviour
{
	public Collider[] colliders;
	static Rigidbody rb;
	public static Vector3 diceVelocity;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		diceVelocity = rb.velocity;

		if (Rules.states == Rules.MyEnum.ROLL_BUILDDICE)
		{
			IsTriggers(true);
			Rules.states = Rules.MyEnum.SHOW_DICE;
			Rules.DiceChoose = "Build Dice";
			DiceCheckZoneScript.diceNumber = 0;
			float dirX = Random.Range(0, 500);
			float dirY = Random.Range(0, 500);
			float dirZ = Random.Range(0, 500);
			transform.position = new Vector3(475, 12, 71);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 500);
			rb.AddTorque(dirX, dirY, dirZ);
		}
	}




	public void IsTriggers(bool onOff)
	{
		for (int i = 0; i < 6; i++)
		{
			colliders[i].isTrigger = onOff;
		}
	}


	public void DisappearDice()
	{
		transform.position = new Vector3(0, 0, 0);
		transform.rotation = Quaternion.identity;
		rb.AddForce(transform.up * 500);
	}
}
