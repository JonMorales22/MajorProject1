using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {
	// Use this for initialization
	public float speed;
	public Transform[] waypoints;
	private Vector2 asdf;
	private int index;
	// Update is called once per frame
	void Start()
	{
		index = 0;
		asdf = new Vector2(waypoints[0].position.x,waypoints[0].position.y);
	}
	void Update () {
		float delta = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards (transform.position, asdf, delta);
		float distance = Mathf.Sqrt((transform.position.y-waypoints[index].position.y)*(transform.position.y-waypoints[index].position.y));
		//Debug.Log (distance);
		if (distance < .01f)
		{
			Debug.Log ("if");
			//asdf = new Vector2 (waypoints [1].position.x, waypoints [1].position.y);
			asdf = GetWayPoint();
		}
	}
	Vector2 GetWayPoint()
	{
		index++;
		if (index == waypoints.Length)
			index = 0;
		
		Vector2 temp = new Vector2 (waypoints[index].position.x, waypoints[index].position.y);
		return temp;
	}
}
