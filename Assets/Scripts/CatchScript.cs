using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatchScript : MonoBehaviour {
	public Transform player;
	public GameObject playerGB;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("Player")) {
			PlayerController script = playerGB.GetComponent<PlayerController> ();
			PlayerPrefs.SetInt ("247127CurrentPlayerScore", script.score);
			SceneManager.LoadScene (2);
		} 
		
	}
}
