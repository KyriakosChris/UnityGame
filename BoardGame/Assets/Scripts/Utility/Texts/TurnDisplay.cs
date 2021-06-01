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

	// Update is called once per frame
	void Update()
	{
		text.text = "TURN : "+Rules.Turn_Counter.ToString();

	}
}
