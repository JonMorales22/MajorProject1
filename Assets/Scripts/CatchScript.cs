using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatchScript : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("Player"))
			SceneManager.LoadScene (0);
		
	}
}
