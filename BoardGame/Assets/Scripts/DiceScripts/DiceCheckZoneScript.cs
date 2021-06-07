using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
	Vector3 diceVelocity;
	Vector3 BuilddiceVelocity;
	public static int diceNumber;
	public static string BuildDice;
	// Update is called once per frame
	void FixedUpdate()
	{
		diceVelocity = DiceScript.diceVelocity;
		BuilddiceVelocity = BuildDiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (col.name.Contains("Side") && Rules.Roll1DicePerTurn)
		{
			if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && diceNumber == 0)
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
				
				col.GetComponentInParent<DiceScript>().IsTriggers(false);
				col.GetComponentInParent<DiceScript>().DisappearDice();

				StartCoroutine(MoveToNextNode());
				
			}
		}
		if (col.name.Contains("Build") && Rules.states == Rules.MyEnum.SHOW_DICE && Rules.DiceChoose == "Build Dice")
		{
			if (BuilddiceVelocity.x == 0f && BuilddiceVelocity.y == 0f && BuilddiceVelocity.z == 0f)
			{

				switch (col.gameObject.name)
				{
					case "Build1":
						BuildDice = "Red";
						break;
					case "Build2":
						BuildDice = "Green";
						break;
					case "Build3":
						BuildDice = "2";
						break;
					case "Build4":
						BuildDice = "H";
						break;
					case "Build5":
						BuildDice = "Green";
						break;
					case "Build6":
						BuildDice = "Green";
						break;
				}
				Rules.states = Rules.MyEnum.ACTION_BUILDDICE;
				col.GetComponentInParent<BuildDiceScript>().IsTriggers(false);
				col.GetComponentInParent<BuildDiceScript>().DisappearDice();
				//Debug.Log("Dice: "+BuildDice);
				Rules.DiceChoose = "Normal Dice";
				

			}
		}
	}


	IEnumerator MoveToNextNode()
	{
		diceNumber = 1;
		if (Rules.Turn_Counter <= 2)
		{
			diceNumber++;
		}
		
		for (int i = 1; i <= diceNumber; i++)
		{
			CarManager.GetInstance().MoveToNext();
			//Debug.Log("Rolled:  "+ diceNumber + "  Steps : " + i);
			yield return new WaitForSeconds(1);
		}
		// If they end up in the same block, move to the next one.
		if(GameObject.FindGameObjectWithTag("Player 1").GetComponent<Player>().locationIndex ==
			GameObject.FindGameObjectWithTag("Player 2").GetComponent<Player>().locationIndex)
        {
			CarManager.GetInstance().MoveToNext();
			yield return new WaitForSeconds(1);
		}
		diceNumber = 0;

		Rules.states = Rules.MyEnum.CHECK_NODE;
	}
}


