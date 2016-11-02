using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.CompareTag ("Player"))
		{
			Debug.Log ("Winrar!!!!11!!1!11!");
			PlayerStats stats = c.gameObject.GetComponent<PlayerStats> ();
			PlayerPrefs.SetInt ("247127CurrentPlayerScore", stats.score);
			SceneManager.LoadScene (2);
		}
	}
}
