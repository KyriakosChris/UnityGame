using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

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

		if (Input.GetKeyDown(KeyCode.Space))
		{
			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range(10, 500);
			float dirY = Random.Range(10, 500);
			float dirZ = Random.Range(10, 500);
			transform.position = new Vector3(477, 12, 73);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 500);
			rb.AddTorque(dirX, dirY, dirZ);
		}
	}
}
