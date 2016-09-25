using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject poop;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - poop.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = poop.transform.position+offset;
	}
}
