using UnityEngine;
using System.Collections;

public class CatchScript : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		Debug.Log ("Collider");

		if (c.gameObject.CompareTag ("Player"))
			player.position=new Vector3 (0, 0, 0);
		
	}
}
