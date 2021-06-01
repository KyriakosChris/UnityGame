using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
	Vector3 diceVelocity;
	public static int diceNumber;
	// Update is called once per frame
	void FixedUpdate()
	{
		diceVelocity = DiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (col.name.Contains("Side") && Rules.Roll1DicePerTurn)
		{
			if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && diceNumber==0)
			{

				switch (col.gameObject.name)
				{
					case "Side1":
						diceNumber = 6;
						break;
					case "Side2":
						diceNumber = 5;
						break;
					case "Side3":
						diceNumber = 4;
						break;
					case "Side4":
						diceNumber = 3;
						break;
					case "Side5":
						diceNumber = 2;
						break;
					case "Side6":
						diceNumber = 1;
						break;
				}
				Rules.states = Rules.MyEnum.MOVE_PLAYER;
				Rules.Roll1DicePerTurn = false;
				col.GetComponentInParent<DiceScript>().isTriggers(false);
				StartCoroutine(MoveToNextNode());
			}
		}
	}

	IEnumerator MoveToNextNode()
    {
        if (Rules.Turn_Counter <= 2)
        {
			diceNumber++;
			Debug.Log("Rolled:");
		}
		for (int i = 1; i <= diceNumber; i++)
		{
			CarManager.getInstance().MoveToNext();
			//Debug.Log("Rolled:  "+ diceNumber + "  Steps : " + i);
			yield return new WaitForSeconds(1);
		}
		diceNumber = 0;

		Rules.states = Rules.MyEnum.CHECK_NODE;
	}
}
