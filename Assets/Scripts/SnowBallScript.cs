using UnityEngine;
using System.Collections;

public class SnowBallScript : MonoBehaviour {
	public float delta;
	public float deltaMass;
	public GameObject start;
	public GameObject prefab;

	private float lockPos=0;
	private Rigidbody2D rb;
	private Vector3 deltaVector;
	private bool isGrowing;
	// Use this for initialization
	void Start () {
		//childTransform = GetComponentInChildren<Transform> ();
		rb = GetComponent<Rigidbody2D> ();
		//deltaVector = new Vector3 (delta, delta, 0);
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
			float temp = Mathf.Abs(rb.velocity.x / 2);
			deltaVector = new Vector3 (temp*delta,delta*temp);
			rb.mass += temp*deltaMass;
			transform.localScale += deltaVector;
			yield return new WaitForSeconds (.1f);
		}
		isGrowing = false;
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.CompareTag ("Player"))
		{
			Debug.Log ("Above");
		}

	}
		
	void OnDestroy()
	{
		SendMessageUpwards ("Spawn");
	}
}
