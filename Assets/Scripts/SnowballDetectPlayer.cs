using UnityEngine;
using System.Collections;

public class SnowballDetectPlayer : MonoBehaviour {
	public Transform snowballTrans;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		//offset = transform.position - snowballTrans.position;
		//Debug.Log ("Offset: " + offset);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (0, transform.position.y);
	}
}
