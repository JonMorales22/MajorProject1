using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.CompareTag ("Player"))
		{
			PlayerStats stats = c.gameObject.GetComponent<PlayerStats> ();
			PlayerPrefs.SetInt ("247127PreviousScore", stats.score);
			Scene activeScene = SceneManager.GetActiveScene ();
			//int temp = activeScene.buildIndex;
			//int numOfScenes = SceneManager.sceneCountInBuildSettings;
			if (activeScene.buildIndex < SceneManager.sceneCountInBuildSettings-1) {
				SceneManager.LoadScene (activeScene.buildIndex + 1);
			}
			else
				SceneManager.LoadScene ("HighScore");
		}
	}
}
