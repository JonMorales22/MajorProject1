using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float limit;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		if(player.transform.position.y<limit){
			//USE THIS IF YOU ONLY WANT CAMERA TO MOVE IN X DIRECTION!!!
			transform.position = new Vector3(player.transform.position.x+offset.x,0,offset.z);
		}
		else if(player.transform.position.y>=limit)
			transform.position = new Vector3(player.transform.position.x,player.transform.position.y,0)+offset;
	}
}
