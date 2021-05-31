using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
	Vector3 diceVelocity;
    // Update is called once per frame
    void FixedUpdate()
	{
		diceVelocity = DiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (col.name.Contains("Side") && Rules.Roll1DicePerTurn)
		{
			if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
			{

				switch (col.gameObject.name)
				{
					case "Side1":
						DiceNumberTextScript.diceNumber = 6;
						break;
					case "Side2":
						DiceNumberTextScript.diceNumber = 5;
						break;
					case "Side3":
						DiceNumberTextScript.diceNumber = 4;
						break;
					case "Side4":
						DiceNumberTextScript.diceNumber = 3;
						break;
					case "Side5":
						DiceNumberTextScript.diceNumber = 2;
						break;
					case "Side6":
						DiceNumberTextScript.diceNumber = 1;
						break;
				}
				Rules.Roll1DicePerTurn = false;
				col.GetComponentInParent<DiceScript>().isTriggers(false);
				StartCoroutine(MoveToNextNode());
			}
		}
	}

	IEnumerator MoveToNextNode()
    {
		for (int i = 0; i <= DiceNumberTextScript.diceNumber; i++)
		{
			CarManager.getInstance().MoveToNext();
			yield return new WaitForSeconds(1);
		}
	}
}
