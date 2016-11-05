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
			PlayerPrefs.SetInt ("247127PreviousScore", stats.score);

			int temp = 0;
			Scene scene = SceneManager.GetActiveScene ();
			temp = scene.buildIndex+1;
			if (temp == SceneManager.sceneCountInBuildSettings)
				SceneManager.LoadScene (1);
			else
				SceneManager.LoadScene (temp);
		}
	}
}
