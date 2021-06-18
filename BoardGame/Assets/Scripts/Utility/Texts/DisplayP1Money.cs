using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayP1Money : MonoBehaviour
{
	TextMeshProUGUI text;

	
	void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	// Display player1 money
	void Update()
	{
		text.text = Rules.P1Money.ToString();


	}
}
