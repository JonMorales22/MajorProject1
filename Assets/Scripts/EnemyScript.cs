using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	[HideInInspector]
	public bool isFacingRight = true;
	[HideInInspector]
	public bool isJumping = false;
	[HideInInspector]
	public bool isGrounded = false;

	public float walkSpeed=7.0f;
	public float maxSpeed=14.0f;
	public float jumpForce = 750.0f; 


	public Transform groundCheck;
	public LayerMask groundLayers;

	public Animator anim;


	//private float groundCheckRadius = .2f;
	private bool isDead = false;
	private Rigidbody2D enemyRB;
	private int move = 1;
	private GameObject thisGB;

	// Use this for initialization
	void Start () {
		enemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isDead) {
			enemyRB.velocity = new Vector2 (move * walkSpeed, enemyRB.velocity.y);

			if ((move > 0.0f && !isFacingRight) || (move < 0.0 && isFacingRight)) {
				Flip ();
			}
		}
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x*-1;
		transform.localScale = playerScale;

	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("Wall")) {
			Flip ();
			move *= -1;
		}
		if (c.gameObject.CompareTag ("Catch"))
			Destroy (gameObject);
	}
}
