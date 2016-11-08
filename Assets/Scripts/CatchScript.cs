using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatchScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("Player")) {
			Scene scene = SceneManager.GetActiveScene (); 
			SceneManager.LoadScene (scene.buildIndex);
		}
		else
		{
			Destroy (c.gameObject);
		}
	}
}
