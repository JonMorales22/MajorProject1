using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {
	public float speed;
	public Transform[] waypoints;
	public bool isMoving;
	public bool goBackwards;

	private bool isDead;
	private Vector2 asdf;
	private int index;
	// Use this for initialization
	void Start () {
		index = 0;
		asdf = new Vector2(waypoints[0].position.x,waypoints[0].position.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
				float delta = speed * Time.deltaTime;
				transform.position = Vector2.MoveTowards (transform.position, asdf, delta);
				float xVal = (transform.position.x - waypoints [index].position.x) * (transform.position.x - waypoints [index].position.x);
				float yVal = (transform.position.y - waypoints [index].position.y) * (transform.position.y - waypoints [index].position.y);
				float distance = Mathf.Sqrt (xVal + yVal);
				//Debug.Log (distance);
				if (distance < .01f) {
					//Debug.Log ("if");
					//asdf = new Vector2 (waypoints [1].position.x, waypoints [1].position.y);
					asdf = GetWayPoint ();
			}
		}
	}

	Vector2 GetWayPoint()
	{

		index++;
		if (index == waypoints.Length)
			index = 0;
		Vector2 temp = new Vector2 (waypoints [index].position.x, waypoints [index].position.y);
		return temp;
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.CompareTag ("Player"))
		{	if(!isMoving)
				isMoving = true;
			c.gameObject.transform.SetParent (gameObject.transform);
		}


	}

	void OnCollisionExit2D(Collision2D c)
	{
		if (c.gameObject.CompareTag ("Player"))
		{
			c.gameObject.transform.SetParent (null);
		}
	}
}
