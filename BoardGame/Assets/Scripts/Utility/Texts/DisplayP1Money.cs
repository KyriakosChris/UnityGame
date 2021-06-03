using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayP1Money : MonoBehaviour
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
		text.text = Rules.P1Money.ToString();


	}
}
