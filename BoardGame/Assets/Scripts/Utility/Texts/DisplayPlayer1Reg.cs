using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayPlayer1Reg : MonoBehaviour
{
	TextMeshProUGUI text;
	public static string region=" ";
	// Use this for initialization
	void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		text.text = "Player 1 "+region.ToString();


    }
}