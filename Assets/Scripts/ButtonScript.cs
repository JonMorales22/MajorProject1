using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public void LoadScene(int i)
	{
		if(PlayerPrefs.HasKey("247127CurrentScore"))
			PlayerPrefs.DeleteKey("247127CurrentScore");

		SceneManager.LoadScene (i);
	}
}
