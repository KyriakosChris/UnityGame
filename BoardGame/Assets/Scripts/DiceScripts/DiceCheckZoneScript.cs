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

	/* 
	 IF a Dice Enter in The Zone Collider, it Displays The result. If it is RollDice, The player Move or Pay.
	 If it is The buildDice The Player learns if he will build and the final price. 
	*/
	void OnTriggerStay(Collider col)
	{
		// Use this boolean to roll the dice only a time per turn
		if ((col.name.Contains("Side") && Rules.Roll1DicePerTurn))
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
				if (!Rules.Pay)
					StartCoroutine(MoveToNextNode());
                else
                {
					Rules.states = Rules.MyEnum.PAY;

				}
				Rules.Pay = false;

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
				Rules.CamChange();


			}
		}
	}


	IEnumerator MoveToNextNode()
	{
		bool secureDrift = true;
		// Fixes a bug at The start of the turn.
		if (Rules.Turn_Counter <= 2)
		{
			secureDrift = false;
			diceNumber++;
		}
		
		//Move The Player to the Next node and play some sounds. The next target node changes after 1 second.
		for (int i = 1; i <= diceNumber; i++)
		{
			FindObjectOfType<AudioManager>().Play("CarSound");
			CarManager.GetInstance().MoveToNext();
			yield return new WaitForSeconds(1);

			// Drift Audio
			string turn = TurnManager.GetInstance().GetCurrentPlayer().ToString();
			GameObject player = GameObject.FindGameObjectWithTag(turn);
			NodeList nodelist = GameObject.FindGameObjectWithTag("Inspector").GetComponent<NodeList>();


			//If a car passes by the other Player, Horns!
			if (GameObject.FindGameObjectWithTag("Player 1").GetComponent<Player>().locationIndex ==
				  GameObject.FindGameObjectWithTag("Player 2").GetComponent<Player>().locationIndex)
			{
				FindObjectOfType<AudioManager>().Play("CarHorn");

			}
			// Drift even if it is in the node before the decor
			if (nodelist.nodes[(player.GetComponent<Player>().locationIndex-1) % nodelist.nodes.Length].name.Equals("Decor Node") && secureDrift)
			{
				FindObjectOfType<AudioManager>().Play("Drift");
			}
			//Always Drift at the corners :)
			if (nodelist.nodes[(player.GetComponent<Player>().locationIndex) % nodelist.nodes.Length].name.Equals("Decor Node") && i<diceNumber)
            {
				FindObjectOfType<AudioManager>().Play("Drift");
            }
			secureDrift = false;
		}
		// If they end up in the same block, move to the next one.
		if(GameObject.FindGameObjectWithTag("Player 1").GetComponent<Player>().locationIndex ==
			GameObject.FindGameObjectWithTag("Player 2").GetComponent<Player>().locationIndex)
        {
			FindObjectOfType<AudioManager>().Play("CarHorn");
			CarManager.GetInstance().MoveToNext();
			yield return new WaitForSeconds(1);
		}

		diceNumber = 0;
		
		InitVars.Endturn.SetActive(true);
		Rules.states = Rules.MyEnum.CHECK_NODE;
	}
}


