using UnityEngine;
using System.Collections;

public class OneUpScript : MonoBehaviour {
	public float force;
	public LayerMask groundLayers;
	public Transform groundCheck;

	private bool isJumping;
	private bool isGrounded;
	private bool isGrowing;

	private Rigidbody2D rb;
	private int count;
	private Animator anim;
	private float groundCheckRadius = .2f;
	// Use this for initialization
	void Start () {
		count = 0;
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		//StartCoroutine ("GrowAnimation");
	}
	
	// Update is called once per framea
	void Update () {
		
		if (!isJumping&isGrounded&&!isGrowing)
		{
			isJumping = true;
			StartCoroutine("Jump");
		}
	}
	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position + new Vector3 (0, -0.5f, 0), groundCheckRadius, groundLayers);

	}
	IEnumerator Jump()
	{
		if (isJumping && count < 4) {
			count++;
			rb.AddForce (new Vector2 (0, force));
		}
		else if(count>=4)
		{
			count = 0;
			StartCoroutine ("Grow");
		}
		yield return new WaitForSeconds(2.0f);
		isJumping = false;
	}

	IEnumerator Grow()
	{
		isGrowing = true;
		anim.SetBool ("isGrowing", true);
		yield return new WaitForSeconds (3.5f);
		anim.SetBool ("isGrowing", false);
		isGrowing = false;
	}
}
