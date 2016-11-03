using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {
	// Use this for initialization
	public float speed;
	public Transform[] waypoints;
	// Update is called once per frame
	void Start()
	{

	}
	void Update () {
		float delta = speed * Time.deltaTime; 
		//Debug.Log (Mathf.Abs (transform.position.y) - waypoints [0].position.y);
		if (transform.position.y - Mathf.Abs(waypoints [0].position.y)<.1f) 
		{
			//Debug.Log ("1");
			Vector2 asdf = new Vector2 (waypoints [1].position.x,waypoints[1].position.y);
			transform.position = Vector2.MoveTowards (transform.position, asdf, delta);
		}
		else 
		{
			//Debug.Log ("2");
			Vector2 asdf = new Vector2 (waypoints [0].position.x,waypoints[0].position.y);
			transform.position = Vector2.MoveTowards (transform.position, asdf, delta);
		}
	}
}
