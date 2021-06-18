using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayP2Money : MonoBehaviour
{
	TextMeshProUGUI text;

	
	void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	// Display player2 money
	void Update()
	{
		text.text = Rules.P2Money.ToString();


	}
}
