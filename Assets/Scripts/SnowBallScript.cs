using UnityEngine;
using System.Collections;

public class SnowBallScript : MonoBehaviour {
	public float delta;
	public float deltaMass;

	private Rigidbody2D rb;
	private Vector3 deltaVector;
	private bool isGrowing;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		deltaVector = new Vector3 (delta, delta, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Mathf.Abs(rb.velocity.x) > .1)
		{
			if (transform.localScale.x < 5&&!isGrowing)
			{
				isGrowing = true;
				StartCoroutine ("Grow");
			}
		}
	}

	IEnumerator Grow()
	{
		while (transform.localScale.x < 5&&Mathf.Abs(rb.velocity.x)>.1)
		{
			rb.mass += deltaMass;
			transform.localScale += deltaVector;
			yield return new WaitForSeconds (.1f);
		}
		isGrowing = false;
	}
}
