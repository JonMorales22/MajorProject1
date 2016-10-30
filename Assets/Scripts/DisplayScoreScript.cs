using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScoreScript : MonoBehaviour {
	public GameObject playerGB;

	private PlayerStats stats;
	private Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
		stats = playerGB.GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = stats.score.ToString();
	}
}
