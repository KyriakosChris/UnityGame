using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TurnDisplay : MonoBehaviour
{

	TextMeshProUGUI text;


	// Use this for initialization
	void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	// Display Current Turn Number;
	void Update()
	{
		text.text = "TURN : "+Rules.Turn_Counter.ToString();

	}
}
