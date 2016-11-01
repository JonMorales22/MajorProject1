using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	void Start(){
		Scene scene = SceneManager.GetActiveScene();
		if (scene.buildIndex == 0 || scene.buildIndex == 2)
		{
			if (PlayerPrefs.HasKey ("247127CurrentPlayerHealth"))
				PlayerPrefs.DeleteKey ("247127CurrentPlayerHealth");
			if (PlayerPrefs.HasKey ("247127CurrentPlayerLives"))
				PlayerPrefs.DeleteKey ("247127CurrentPlayerLives");
		}
		if(scene.buildIndex==0)
			if (PlayerPrefs.HasKey ("247127CurrentPlayerScore"))
				PlayerPrefs.DeleteKey ("247127CurrentPlayerScore");

	}
	public void LoadScene(int i)
	{
		SceneManager.LoadScene (i);
	}

	public void ClearScores()
	{
		PlayerPrefs.DeleteAll ();
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
