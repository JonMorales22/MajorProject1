using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayLives : MonoBehaviour {

	private Text text;
	private int lives;
	public AudioClip sound;

	void Start () {
		text = GetComponent<Text> ();
		if (PlayerPrefs.HasKey ("247127CurrentPlayerLives"))
			lives = PlayerPrefs.GetInt ("247127CurrentPlayerLives");
		else
			lives = 3;
		text.text = lives.ToString ();
	}

	public void playSound(Vector3 pos)
	{
		AudioSource.PlayClipAtPoint (sound,pos);
	}

	public void UpdateLives(int value)
	{
		lives = PlayerPrefs.GetInt ("247127CurrentPlayerLives");
		text.text = lives.ToString ();
	}
}
