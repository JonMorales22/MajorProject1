using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScoreScript : MonoBehaviour {
	public GameObject playerGB;

	private PlayerController script;
	private Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
		script = playerGB.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = script.score.ToString();
	}
}
