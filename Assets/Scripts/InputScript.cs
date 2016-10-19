using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputScript : MonoBehaviour {

	/// <summary>
	/// Script that enables and disables buttons. 
	/// 1. We assume we need input until the HighScoreScript tells us we don't.
	/// 2. If we don't need input, we just disable the inputBox and the enterButton and enable the rest of the GameObjects
	/// 3. If we do need input, we disable all the stuff when the user clicks on enterButton 
	/// </summary>

	public string initials;
	public bool flag;

	public GameObject parent;
	public GameObject postInputUIHolder;
	public InputField input;
	/*
	public GameObject textHolder; // <--- this is where the text of the player names and highscores is stored
	public GameObject enterButton; //
	public GameObject playButton;
	public GameObject exitButton;
	public GameObject inputBox;
	public GameObject text;
	public InputField input;
	*/
	public void getInput(){
		initials = input.text;
		flag = true;
		activeButtons ();
	}

	public void activeButtons(){
		parent.SetActive (false);
		postInputUIHolder.SetActive (true);
	}
}
