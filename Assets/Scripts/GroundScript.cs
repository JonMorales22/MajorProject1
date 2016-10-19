using UnityEngine;
using System.Collections;

public class GroundScript : MonoBehaviour {
	//private Transform thisTrans;
	private bool isFalling = false;
	// Use this for initialization
	void Start () {
		//thisTrans = GetComponent<Transform> ();
	}
	void FixedUpdate()
	{
		if(isFalling)
			transform.position += new Vector3(0,-1,0);
		if (transform.position.y < -10)
			Destroy (gameObject);

	}
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.CompareTag ("Catch"))
			Destroy (gameObject);
	}
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.CompareTag ("Player"))
			StartCoroutine ("Fall");
	}

	IEnumerator Fall(){
		yield return new WaitForSeconds (3.0f);
		isFalling = true;
	}
}
