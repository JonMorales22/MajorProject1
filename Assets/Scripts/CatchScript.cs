using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatchScript : MonoBehaviour {
	public Transform player;
	//public GameObject playerGB;
	private PlayerStats stats;
	// Use this for initialization
	void Start () {
		stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("Player")) {
			stats = c.gameObject.GetComponent<PlayerStats> ();
			if (!stats.isDead)
				SceneManager.LoadScene (1);
			else {
				PlayerPrefs.SetInt ("247127CurrentPlayerScore",stats.score);
				SceneManager.LoadScene (2);
			}
		} 
		
	}
}
